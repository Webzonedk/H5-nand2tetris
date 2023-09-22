using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VM.Interfaces;
using VM.Managers;
using VM.Mappers;
using VM.Tools;
using VM.Translators;


namespace VM
{
    class Program
    {
        private readonly IVmConverter _vmConverter;
        public static IConfiguration? Configuration;

        public Program(IVmConverter vmConverter)
        {
            _vmConverter = vmConverter;
        }


        /// <summary>
        /// This is the main method of the program. addin dependencyinjections
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
                .AddTransient<ICommandMapper, CommandMapper>()
                .AddTransient<ISegmentHandler, SegmentHandler>()
                .AddTransient<ITranslateWithCommandOnly, TranslateAdd>()
                .AddTransient<ITranslateWithCommandOnly, TranslateSub>()
                .AddTransient<ITranslateWithCommandOnly, TranslateNeg>()
                .AddTransient<ITranslateWithUniqueCounter, TranslateEq>()
                .AddTransient<ITranslateWithUniqueCounter, TranslateGt>()
                .AddTransient<ITranslateWithUniqueCounter, TranslateLt>()
                .AddTransient<ITranslateWithCommandOnly, TranslateAnd>()
                .AddTransient<ITranslateWithCommandOnly, TranslateOr>()
                .AddTransient<ITranslateWithCommandOnly, TranslateNot>()
                .AddTransient<ITranslateWithLocationAndValue, TranslatePush>()
                .AddTransient<ITranslateWithLocationAndValue, TranslatePop>()
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
            Console.WriteLine("Press any key to exit...");
        }
    }
}
