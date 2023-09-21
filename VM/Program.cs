using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


using System.Drawing;
using VM.Interfaces;
using VM.Managers;

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
                //.AddTransient<IFileReader, FileReader>()
                .AddTransient<IVmConverter, VmConverter>()
                //.AddTransient<ISymbolsDynamicTable, SymbolsDynamicTable>()
                //.AddTransient<ISymbolsPredefinedTable, SymbolsPredefinedTable>()
                //.AddTransient<ICInstructionTable, CInstructionTable>()
                //.AddTransient<ICInstructionSplitter, CInstructionSplitter>()
                //.AddTransient<ICInstructionAssembler, CInstructionAssembler>()
                //.AddTransient<ICInstructionConverter, CInstructionConverter>()
                //.AddTransient<ILabelsDynamicTable, LabelsDynamicTable>()
                .AddTransient<Program, Program>()
                .BuildServiceProvider();

            // Create an instance of Program and resolve its dependencies
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
