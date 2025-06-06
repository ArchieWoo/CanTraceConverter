using CanTraceConverter.Models;
using Microsoft.Win32;
using System.Windows;
using Path = System.IO.Path;

namespace CanTraceConverter.DemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string _inputFilePath = string.Empty;
        private string _inputFileName = string.Empty;
        private string _outputFilePath = string.Empty;
        private string _outputFileName = string.Empty;
        private TraceType traceType;
        private IConverter _converter;
        private void OpenInputFileCommand(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = "",
                RestoreDirectory = true,
                Filter = "TRC File (*.trc)|*.trc|ASC File (*.asc)|*.asc|All Files (*.*)|*.*",
            };

            ofd.ShowDialog();
            if (string.IsNullOrEmpty(ofd.FileName))
                return;
            IConverter converter = new Converter(ofd.FileName);
            if (converter.IsValidTrace())
            {
                _inputFilePath = ofd.FileName;
                _inputFileName = Path.GetFileName(_inputFilePath);
                traceType = converter.GetTraceType();

                if (traceType == TraceType.TraceType_Vector)
                {
                    _outputFilePath = Path.ChangeExtension(_inputFilePath, ".trc");
                    _outputFileName = Path.GetFileName(_outputFilePath);
                }
                else if (traceType == TraceType.TraceType_Pcan)
                {
                    _outputFilePath = Path.ChangeExtension(_inputFilePath, ".asc");
                    _outputFileName = Path.GetFileName(_outputFilePath);
                }

                InputFilePath.Text = _inputFilePath;
                InputFileName.Text = _inputFileName;
                OutputFilePath.Text = _outputFilePath;
                OutputFileName.Text = _outputFileName;
                InputTraceType.Text = traceType.ToString();
                _converter = converter;
            }

        }
        private void ConvertCommand(object sender, RoutedEventArgs e)
        {
            if (_converter == null)
                return;

            _converter.ConvertTraceToVector()
            .SaveToPathFile(_outputFilePath);

            if(_converter.IsWriteFinished())
            {
                MessageBox.Show("Trace has been converted sucessfully.");
            }
        }
    }
}