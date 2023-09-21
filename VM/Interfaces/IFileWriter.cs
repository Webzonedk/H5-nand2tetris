using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Interfaces
{
    internal interface IFileWriter
    {
        public void WriteToFile(string fileNameWithoutExtension, StringBuilder fileContent);
    }
}
