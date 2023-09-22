namespace VM.Tools
{
    /// <summary>
    /// This interface is responsible for handling the segments
    /// </summary>
    internal interface ISegmentHandler
    {
        public string TranslateSegment(string segment, string value);
    }
}