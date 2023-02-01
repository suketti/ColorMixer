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

namespace ColorMixer
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


        private void BtnFix(object sender, RoutedEventArgs e)
        {
            String colorData = $"{Convert.ToByte(sliRed.Value)};{Convert.ToByte(sliGreen.Value)};{Convert.ToByte(sliBlue.Value)}";
            if (!lbColors.Items.Contains(colorData)) {
                lbColors.Items.Add(colorData);
            }
        }

        private void BtnDelete(object sender, RoutedEventArgs e)
        {
            if (lbColors.SelectedIndex>=0)
            {
                lbColors.Items.RemoveAt(lbColors.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem");
            }
        }

        private void BtnUnload(object sender, RoutedEventArgs e)
        {
            lbColors.Items.Clear();
        }

        private void sli_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rctRectangle.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliRed.Value), Convert.ToByte(sliGreen.Value), Convert.ToByte(sliBlue.Value)));
        }

        private void PassColor(object sender, MouseButtonEventArgs e)
        {
            string[] items = { "0", "0", "0" };
            if (lbColors.SelectedItem != null)
            {
                items = lbColors.SelectedItem.ToString().Split(';');
            }
            sliRed.Value = Convert.ToByte(items[0]);
            sliGreen.Value = Convert.ToByte(items[1]);
            sliBlue.Value = Convert.ToByte(items[2]);
        }
    }
}
