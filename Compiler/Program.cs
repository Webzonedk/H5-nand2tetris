using Compiler.Interfaces;
using Compiler.Managers;
using Compiler.Tables;
using Compiler.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler
{
    /// <summary>
    /// This is the main class of the program.
    /// </summary>
    class Program
    {
        private readonly IFileConverter _fileConverter;

        public Program(IFileConverter fileConverter)
        {
            _fileConverter = fileConverter;
        }

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
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