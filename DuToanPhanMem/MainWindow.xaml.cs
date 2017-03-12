using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using DuToanPhanMem.Model;

namespace DuToanPhanMem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChiPhiPhanMem cp = new ChiPhiPhanMem { GiaTriPhanMem = 0, ChiPhiChung = 0,  Thue = 0, Tong=0};

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = cp;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void HlGiaTri_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void HlChiPhi_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void HlThue_OnClick(object sender, RoutedEventArgs e)
        {
           
        }

        

        private void BtnDuToan_OnClick(object sender, RoutedEventArgs e)
        {
            cp.TinhChiPhi();
            BtnDuToan.IsEnabled = false;
        }

       
    }
}
