namespace CanTraceConverter.Models
{
    public class CanMessage
    {
        public uint ID { get; set; }
        public ushort LEN { get; set; }
        public byte[] DATA { get; set; }
        //Uint us
        public uint TimeStamp { get; set; }
        public string Dir { get; set; }
    }
}
