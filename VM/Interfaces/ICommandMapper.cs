using System.Text;

namespace VM.Interfaces
{
    internal interface ICommandMapper
    {
        Dictionary<string, Action<StringBuilder>> CommandMap { get; }
        public Dictionary<string, Action<int, StringBuilder>> CommandMapWithUniqueCounter { get; }
        Dictionary<string, Action<string, string, StringBuilder>> CommandWithLocationAndValueMap { get; }
        Dictionary<string, Action<string, StringBuilder>> CommandWithLocationMap { get; }
    }
}