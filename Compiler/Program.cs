using Compiler.Interfaces;
using Compiler.Managers;
using Compiler.Tables;
using Compiler.Tools;
using System.Text;

namespace Compiler
{
    class Program
    {

        private readonly IFileReader _fileReader;
        private readonly IFileConverter _fileConverter;
        private readonly ISymbolsDynamicTable _symbolsDynamicTable;
        private readonly ISymbolsPredefinedTable _symbolsPredefinedTable;
        private readonly ICInstructionTable _cInstructionTable;
        private readonly ICInstructionSplitter _cInstructionSplitter;
        private readonly ICInstructionAssembler _cInstructionAssembler;
        private readonly ICInstructionConverter _cInstructionConverter;


        public Program(
            IFileReader fileReader,
            IFileConverter fileConverter,
            ISymbolsPredefinedTable symbolsPredefinedTable,
            ISymbolsDynamicTable symbolsDynamicTable,
            ICInstructionTable cInstructionTable,
            ICInstructionSplitter cInstructionSplitter,
            ICInstructionAssembler cInstructionAssembler,
            ICInstructionConverter cInstructionConverter)
        {
            _fileReader = fileReader;
            _fileConverter = fileConverter;
            _symbolsDynamicTable = symbolsDynamicTable;
            _symbolsPredefinedTable = symbolsPredefinedTable;
            _cInstructionSplitter = cInstructionSplitter;
            _cInstructionAssembler = cInstructionAssembler;
            _cInstructionConverter = cInstructionConverter;
            _cInstructionTable = cInstructionTable;
        }

        static void Main(string[] args)
        {
            IFileReader fileReader = new FileReader();
            ISymbolsPredefinedTable symbolsPredefinedTable = new SymbolsPredefinedTable();
            ISymbolsDynamicTable symbolsDynamicTable = new SymbolsDynamicTable();
            ICInstructionTable cInstructionTable = new CInstructionTable();
            ICInstructionSplitter cInstructionSplitter = new CInstructionSplitter();
            ICInstructionAssembler cInstructionAssembler = new CInstructionAssembler(cInstructionTable);
            ICInstructionConverter cInstructionConverter = new CInstructionConverter(cInstructionSplitter, cInstructionAssembler);
            IFileConverter fileConverter = new FileConverter(fileReader, symbolsPredefinedTable, symbolsDynamicTable, cInstructionConverter);


            Program program = new Program(fileReader, fileConverter, symbolsPredefinedTable, symbolsDynamicTable, cInstructionTable, cInstructionSplitter, cInstructionAssembler, cInstructionConverter);
            program.Run();
        }

        public void Run()
        {
            _fileConverter.Compiler();
            Console.WriteLine("Press any key to exit...");
        }
    }
}