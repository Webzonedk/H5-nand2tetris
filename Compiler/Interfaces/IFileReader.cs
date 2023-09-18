using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Interfaces
{
    public interface IFileReader
    {
        public string[] GetFilesFromFolder();
    }
}
