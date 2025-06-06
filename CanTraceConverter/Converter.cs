using CanTraceConverter.Extensions;
using CanTraceConverter.Models;

namespace CanTraceConverter
{
    public class Converter : IConverter
    {
        private readonly string _filePath = string.Empty;
        private string _exportFilePath = string.Empty;
        private List<uint> _includeIds = new List<uint>();
        private List<uint> _excludeIds = new List<uint>();
        private List<CanMessage> _resultMessages = new List<CanMessage>();

        private List<string> _messageContent = new List<string>();
        private string _originalTraceContent = string.Empty;
        private List<string> _originalTraceContentList = new List<string>();
        private DateTime _startTime = DateTime.Now;
        private string _timeString = string.Empty;
        private TraceType _traceType = TraceType.TraceType_Unknown; 
        public Converter(string filePath)
        {
            _filePath = filePath;
            if (!TraceExtensions.IsValidTrace(filePath))
                return;
            _originalTraceContentList = File.ReadAllLines(filePath).ToList();
            _originalTraceContent = string.Join(Environment.NewLine, _originalTraceContentList);
            _traceType = TraceExtensions.GetTraceType(_originalTraceContentList);
            _timeString = TraceExtensions.GetTimeStringFromTrace(_originalTraceContentList, _traceType);
            _startTime = TraceExtensions.ConvertToTimeFromString(_timeString);

        }
        public IConverter ExcludeIds(List<uint> ids)
        {
            _excludeIds = new List<uint>(ids);
            return this;
        }

        public IConverter IncludeIds(List<uint> ids)
        {
            _includeIds = new List<uint>(ids);
            return this;
        }


        public IConverter ConvertTraceToVector()
        {
            
            _resultMessages = TraceExtensions.ParsingCanMessages(_filePath, _includeIds, _excludeIds);
            _messageContent = TraceExtensions.GenMessagesContent(_resultMessages, TraceType.TraceType_Vector,_startTime);
            return this;
        }
        public IConverter ConvertTraceToPcan()
        {
            _resultMessages = TraceExtensions.ParsingCanMessages(_filePath, _includeIds, _excludeIds);
            _messageContent = TraceExtensions.GenMessagesContent(_resultMessages, TraceType.TraceType_Pcan, _startTime);
            return this;
        }
        public IConverter GenMessageStrings(TraceType traceType)
        {
            _messageContent = TraceExtensions.GenMessagesContent(_resultMessages, traceType, _startTime);
            return this;
        }
        public IConverter SaveToPathFile(string path)
        {
            _exportFilePath = path;
            TraceExtensions.SaveTraceFile(_exportFilePath, _messageContent);
            return this;
        }

        public IConverter ParsingCanMessages()
        {
            _resultMessages = TraceExtensions.ParsingCanMessages(_filePath, _includeIds, _excludeIds);
            return this;
        }

        public bool IsWriteFinished()
        {
            return File.Exists(_exportFilePath);
        }
        public bool IsValidTrace()
        {
            if (string.IsNullOrEmpty(_filePath))
                return false;
            return TraceExtensions.IsValidTrace(_filePath);
        }

        public List<CanMessage> GetMessages()
        {
            return _resultMessages;
        }

        public List<uint> GetIncludeIds()
        {
            return _includeIds;
        }

        public List<uint> GetExcludeIds()
        {
            return _excludeIds;
        }

        public string GetConvertedTraceContent()
        {
            return string.Join(Environment.NewLine, _messageContent);
        }

        public string GetOriginalTraceContent()
        {
            return _originalTraceContent;
        }

        public TraceType GetTraceType()
        {
            return _traceType;
        }
    }
}
