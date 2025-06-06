using CanTraceConverter;

string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
LogNormal(appDirectory);

List<string> mathedFiles = new List<string>();
mathedFiles = FindFilesViaExt(appDirectory, "trc");
LogNormal($"Finded {mathedFiles.Count} .trc files");
foreach (string file in mathedFiles)
{
    LogInfo(file);
}
if (mathedFiles.Count == 0)
{
    LogInfo("No matched trc files in this folder. Exit.");
    LogNormal("Processing completed. Press any key to exit...");
    Console.ReadKey(); // Waits for any key press
    return;
}
List<uint> includeIds = new List<uint>();
List<uint> excludeIds = new List<uint>();

foreach (string file in mathedFiles)
{
    try
    {
        LogNormal($"Converting {Path.GetFileName(file)} ...");
        string savePath = Path.ChangeExtension(file, ".asc");
        LogNormal($"Save Path : {savePath}");

        IConverter converter = new Converter(file)
            .IncludeIds(includeIds)
            .ExcludeIds(excludeIds)
            .ConvertTraceToVector()
            .SaveToPathFile(savePath);
        bool result = converter.IsWriteFinished();
        if (result)
        {
            LogSuccess($"{Path.GetFileName(file)} -> {Path.GetFileName(savePath)}");
        }
        else
        {
            LogError($"Convert failed : {file}");
        }

    }
    catch (Exception ex)
    {
        LogError($"Unhandled Exception Error {ex.Message}");
    }

}

LogNormal("Processing completed. Press any key to exit...");
Console.ReadKey(); // Waits for any key press


List<string> FindFilesViaExt(string rootPath, string ext)
{
    List<string> matchedFiles = new List<string>();
    ext = ext.ToLower().Replace("*", "").Replace(".", "");
    try
    {
        foreach (string file in Directory.GetFiles(rootPath, $"*.{ext}", SearchOption.AllDirectories))
        {
            matchedFiles.Add(file);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }

    return matchedFiles;
}

void LogNormal(string message)
{
    string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(logMessage);
    Console.ResetColor();
}
void LogInfo(string message)
{
    string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ℹ️ INFO: {message}";
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(logMessage);
    Console.ResetColor();
}
void LogSuccess(string message)
{
    string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ✅ SUCCESS: {message}";
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(logMessage);
    Console.ResetColor();
}
void LogError(string message)
{
    string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ❌ ERROR: {message}";
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(logMessage);
    Console.ResetColor();
}