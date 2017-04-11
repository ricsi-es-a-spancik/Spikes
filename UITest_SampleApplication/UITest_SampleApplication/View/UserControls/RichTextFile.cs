namespace UITest_SampleApplication.View.UserControls
{
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;

    // https://www.rhyous.com/2011/08/01/loading-a-richtextbox-from-an-rtf-file-using-binding-or-a-richtextfile-control/
    public class RichTextFile : RichTextBox
    {
        private static readonly DependencyProperty FileProperty = DependencyProperty.Register("File", typeof(string), typeof(RichTextFile), new PropertyMetadata(OnFileChanged));

        public string File
        {
            private get { return (string)GetValue(FileProperty); }
            set { SetValue(FileProperty, value); }
        }

        private static void OnFileChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var rtf = d as RichTextFile;

            if (rtf == null)
                return;

            ReadFile(rtf.File, rtf.Document);
        }

        private static void ReadFile(string inFilename, FlowDocument inFlowDocument)
        {
            if (!System.IO.File.Exists(inFilename))
                return;

            var range = new TextRange(inFlowDocument.ContentStart, inFlowDocument.ContentEnd);
            var fStream = new FileStream(inFilename, FileMode.Open, FileAccess.Read, FileShare.Read);

            range.Load(fStream, DataFormats.Rtf);
            fStream.Close();
        }
    }
}
