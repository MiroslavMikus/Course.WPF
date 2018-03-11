using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RichTextBox.Done
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

        #region Formatting
        private void  UltraBold_Click(object sender, RoutedEventArgs e)
        {
            FontWeight actFontWeight = GetWeight();

            FontWeight newFontWeight =
                actFontWeight == FontWeights.UltraBold ? FontWeights.Normal : FontWeights.UltraBold;

            ApplyWeight(newFontWeight);
        }

        private void  Bold_Click(object sender, RoutedEventArgs e)
        {
            FontWeight actFontWeight = GetWeight();

            FontWeight newFontWeight =
                actFontWeight == FontWeights.Bold ? FontWeights.Normal : FontWeights.Bold;

            ApplyWeight(newFontWeight);
        }

        private void  Normal_Click(object sender, RoutedEventArgs e)
        {
            ApplyWeight(FontWeights.Normal);
        }

        private void  Light_Click(object sender, RoutedEventArgs e)
        {
            FontWeight actFontWeight = GetWeight();

            FontWeight newFontWeight =
                actFontWeight == FontWeights.Light ? FontWeights.Normal : FontWeights.Light;

            ApplyWeight(newFontWeight);
        }

        private void  UltraLight_Click(object sender, RoutedEventArgs e)
        {
            FontWeight actFontWeight = GetWeight();

            FontWeight newFontWeight =
                actFontWeight == FontWeights.UltraLight ? FontWeights.Normal : FontWeights.UltraLight;

            ApplyWeight(newFontWeight);
        }
        #endregion

        #region Tools
        private FontWeight GetWeight()
        {
            Object currentFontWeight = RichDocument.Selection.GetPropertyValue(FontWeightProperty);

            try
            {
                return (FontWeight)currentFontWeight;
            }
            catch (InvalidCastException)
            {
                // This ocurrs if you pass in text with multiple formats.
                return FontWeights.Normal;
            }
        }

        private void ApplyWeight(FontWeight fontWeight)
        {
            RichDocument.Selection.ApplyPropertyValue(FontWeightProperty, fontWeight);

            RichDocument.Focus();
        }
        #endregion

        #region Save & Load
        private void  Save_Click(object sender, RoutedEventArgs e)
        {
            FileStorage.StoreToFile(RichDocument.Document);
        }

        private void  Load_Click(object sender, RoutedEventArgs e)
        {
            FileStorage.RestoreFromFile(RichDocument.Document);
        }
        #endregion
    }
}
