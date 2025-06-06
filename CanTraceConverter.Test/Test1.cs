namespace CanTraceConverter.Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string FilePath = "Trace9.trc";
            string SavePath = "Vector.asc";
            List<uint> includeIds = new List<uint>();
            List<uint> excludeIds = new List<uint>();
            IConverter converter = new Converter(FilePath)
                    .IncludeIds(includeIds)
                    .ExcludeIds(excludeIds)
                    .ConvertTraceToVector()
                    .SaveToPathFile(SavePath);
            bool result = converter.IsWriteFinished();
            
        }
    }
}
