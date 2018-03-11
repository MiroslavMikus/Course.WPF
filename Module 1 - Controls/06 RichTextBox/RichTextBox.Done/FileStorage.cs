using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace RichTextBox.Done
{
    public static class FileStorage
    {
        public static void RestoreFromFile(FlowDocument flowDocument)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Text-File|*.txt|XAML-File|*.xaml|RTF-File|*.rtf | All Files | *.* "
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string format = null;

                switch (dialog.FilterIndex)
                {
                    case 1:
                    case 4:
                        format = DataFormats.Text;
                        break;
                    case 2:
                        format = DataFormats.Xaml;
                        break;
                    case 3:
                        format = DataFormats.Rtf;
                        break;
                }

                FlowDocument document = flowDocument;

                TextRange range = new TextRange(document.ContentStart, document.ContentEnd);

                using (var stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    range.Load(stream, format);

                    stream.Close();
                }
            }
        }

        public static void StoreToFile(FlowDocument flowDocument)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Text-File|*.txt|XAML-File|*.xaml|RTF-File|*.rtf"

            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string format = null;

                switch (dialog.FilterIndex)
                {
                    case 1:
                        format = DataFormats.Text;
                        break;
                    case 2:
                        format = DataFormats.Xaml;
                        break;
                    case 3:
                        format = DataFormats.Rtf;
                        break;
                }

                FlowDocument document = flowDocument;

                TextRange range = new TextRange(document.ContentStart, document.ContentEnd);

                using (var stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    range.Save(stream, format);

                    stream.Close();
                }
            }
        }
    }
}
