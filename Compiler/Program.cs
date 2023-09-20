using Compiler.Interfaces;
using Compiler.Managers;
using Compiler.Tables;
using Compiler.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Compiler
{
    /// <summary>
    /// This is the main class of the program.
    /// </summary>
    class Program
    {
        private readonly IFileConverter _fileConverter;
        public static IConfiguration? Configuration { get; set; }

        public Program(IFileConverter fileConverter)
        {
            _fileConverter = fileConverter;
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
                .AddSingleton<IConfiguration>(Configuration)
                .AddTransient<IFileReader, FileReader>()
                .AddTransient<IFileConverter, FileConverter>()
                .AddTransient<ISymbolsDynamicTable, SymbolsDynamicTable>()
                .AddTransient<ISymbolsPredefinedTable, SymbolsPredefinedTable>()
                .AddTransient<ICInstructionTable, CInstructionTable>()
                .AddTransient<ICInstructionSplitter, CInstructionSplitter>()
                .AddTransient<ICInstructionAssembler, CInstructionAssembler>()
                .AddTransient<ICInstructionConverter, CInstructionConverter>()
                .AddTransient<ILabelsDynamicTable, LabelsDynamicTable>()
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
            _fileConverter.Compiler();
            Console.WriteLine("Press any key to exit...");
        }
    }
}