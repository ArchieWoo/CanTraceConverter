using CanTraceConverter.Models;

namespace CanTraceConverter
{
    public interface IConverter
    {
        bool IsValidTrace();
        bool IsWriteFinished();
        List<CanMessage> GetMessages();
        List<uint> GetIncludeIds();
        List<uint> GetExcludeIds();
        string GetConvertedTraceContent();
        string GetOriginalTraceContent();

        IConverter ExcludeIds(List<uint> ids);
        IConverter IncludeIds(List<uint> ids);
        IConverter ConvertTraceToVector();
        IConverter ConvertTraceToPcan();
        IConverter SaveToPathFile(string path);
        IConverter ParsingCanMessages();
        TraceType GetTraceType();
    }
}
