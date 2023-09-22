using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VM.Interfaces;
using VM.Managers;
using VM.Mappers;
using VM.Tools;
using VM.Translators;


namespace VM
{
    /// <summary>
    /// This is the main class of the program. It is responsible for the dependency injection and the running of the program.
    /// </summary>
    class Program
    {
        private readonly IVmConverter _vmConverter;
        public static IConfiguration? Configuration;

        public Program(IVmConverter vmConverter)
        {
            _vmConverter = vmConverter;
        }


        /// <summary>
        /// This is the main method of the program. adding dependency injections
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(Configuration)
                .AddTransient<IVmConverter, VmConverter>()
                .AddTransient<IFileReader, FileReader>()
                .AddTransient<IFileWriter, FileWriter>()
                .AddTransient<ILogFileWriter, LogFileWriter>()
                .AddTransient<ICommandMapper, CommandMapper>()
                .AddTransient<ISegmentHandler, SegmentHandler>()
                .AddTransient<ITranslateAdd, TranslateAdd>()
                .AddTransient<ITranslateSub, TranslateSub>()
                .AddTransient<ITranslateNeg, TranslateNeg>()
                .AddTransient<ITranslateEq, TranslateEq>()
                .AddTransient<ITranslateGt, TranslateGt>()
                .AddTransient<ITranslateLt, TranslateLt>()
                .AddTransient<ITranslateAnd, TranslateAnd>()
                .AddTransient<ITranslateOr, TranslateOr>()
                .AddTransient<ITranslateNot, TranslateNot>()
                .AddTransient<ITranslatePush, TranslatePush>()
                .AddTransient<ITranslatePop, TranslatePop>()
                .AddTransient<ITranslateEndLoop, TranslateEndLoop>()
                //.AddTransient<ITranslateLabel, TranslateLabel>()
                //.AddTransient<ITranslateGoto, TranslateGoto>()
                //.AddTransient<ITranslateIfGoto, TranslateIfGoto>()
                //.AddTransient<ITranslateFunction, TranslateFunction>()
                //.AddTransient<ITranslateCall, TranslateCall>()
                //.AddTransient<ITranslateReturn, TranslateReturn>()
                .AddTransient<Program, Program>()
                .BuildServiceProvider();

            var program = ActivatorUtilities.CreateInstance<Program>(serviceProvider);
            program.Run();
        }



        /// <summary>
        /// This method runs the program.
        /// </summary>
        public void Run()
        {
            _vmConverter.Convert();
        }
    }
}
