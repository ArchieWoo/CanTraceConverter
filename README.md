# 🚗 CanTraceConverter

> A lightweight and cross-platform library for converting CAN trace files between **PCAN** (`.trc`) and **Vector** (`.asc`) formats.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 

---

## 🔧 Features

- Convert PCAN `.trc` file to Vector `.asc` format.
- Convert Vector `.asc` file to PCAN `.trc` format.
- Support filtering by message IDs:
  - Include specific message IDs
  - Exclude specific message IDs
- Lightweight, no external dependencies
- Cross-platform support (.NET 5/6/7/8/9, .NET Core, .NET Framework, .NET Standard 2.0)
- Fluent API design for easy chaining

---

## 📦 Installation via NuGet

```bash
dotnet add package CanTraceConverter
```

Or install from NuGet Package Manager:
```bash
Install-Package CanTraceConverter
```

## 🧩 Usage Example

### Convert a file and save the result:
```csharp
IConverter converter = new Converter("input.trc")
    .IncludeIds(new List<uint> { 0x100, 0x200 })
    .ExcludeIds(new List<uint> { 0x300 })
    .ConvertTraceToVector()
    .SaveToPathFile("output.asc");

bool success = converter.IsWriteFinished(); // Check if conversion succeeded
```
### Get parsed messages directly:
```csharp
List<CanMessage> messages = new Converter("input.trc")
    .ParsingCanMessages()
    .GetMessages();
```
## 🧪 Testing
You can run unit tests using any test runner (e.g., MSTest, xUnit):
```csharp
[TestClass]
public class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        string FilePath = "Trace9.trc";
        string SavePath = "Vector.asc";
        IConverter converter = new Converter(FilePath)
            .ConvertTraceToVector()
            .SaveToPathFile(SavePath);

        Assert.IsTrue(converter.IsWriteFinished());
    }
}
```

## 🖥️ Console Demo Application
A simple console demo is included in the project showing how to:

Search for .trc or .asc files in a folder
Convert them to the other format
Output logs with color coding:
- ✅ Success
- ❌ Error
- ℹ️ Info
Example output:
```bash
[2025-06-06 13:29:34] C:\Users\WQU3WX\Desktop\TestFolder\tracetest\
[2025-06-06 13:29:34] Finded 2 .trc files
[2025-06-06 13:29:34] ℹ️ INFO: C:\Users\XXXXXX\Desktop\TestFolder\tracetest\Trace9.trc
[2025-06-06 13:29:34] ℹ️ INFO: C:\Users\XXXXXX\Desktop\TestFolder\tracetest\TraceFile_Pcan_20250325.trc
[2025-06-06 13:29:34] Converting Trace9.trc ...
[2025-06-06 13:29:34] Save Path : C:\Users\XXXXXX\Desktop\TestFolder\tracetest\Trace9.asc
[2025-06-06 13:29:34] ✅ SUCCESS: Trace9.trc -> Trace9.asc
[2025-06-06 13:29:34] Converting TraceFile_Pcan_20250325.trc ...
[2025-06-06 13:29:34] Save Path : C:\Users\XXXXXX\Desktop\TestFolder\tracetest\TraceFile_Pcan_20250325.asc
[2025-06-06 13:29:34] ✅ SUCCESS: TraceFile_Pcan_20250325.trc -> TraceFile_Pcan_20250325.asc
[2025-06-06 13:29:34] Processing completed. Press any key to exit...
```
## 📁 Supported File Formats

Currently, the following PCAN `.trc` versions are supported:

- ✅ TRC 1.0
- ✅ TRC 1.1
- ✅ TRC 1.2
- ✅ TRC 1.3
- ✅ TRC 2.0
- ✅ TRC 2.1

| Format | Extension | Direction       |
|--------|-----------|-----------------|
| PCAN   | `.trc`    | ➜ Vector `.asc` |
| Vector | `.asc`    | ➜ PCAN `.trc`   |

## 🎯 Target Frameworks
This library supports the following frameworks:

- ✅ .NET 5 / 6 / 7 / 8 / 9
- ✅ .NET Core 3.1
- ✅ .NET Framework 4.6.1 – 4.8.1
- ✅ .NET Standard 2.0

## 📄 License
### MIT License

See LICENSE for details. 

## 🛠️ Build & Contribution
If you'd like to contribute or build this project yourself:
```bash
git clone https://github.com/ArchieWoo/CanTraceConverter.git 
cd CanTraceConverter
dotnet build
```
Pull requests are welcome!

## 📬 Contact
For questions, issues or feature requests, feel free to open an issue on GitHub or reach out directly.

## 🌟 Thank You!
Thanks for checking out CanTraceConverter ! Whether you're working with automotive diagnostics, logging tools or embedded systems, this tool helps streamline your workflow.