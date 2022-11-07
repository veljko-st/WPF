using AP.ViewModel;
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
using System.Windows.Shapes;

namespace AukcijskaProdaja
{
    /// <summary>
    /// Interaction logic for SingInWindow.xaml
    /// </summary>
    public partial class SingInWindow : Window
    {
        public SingInWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SingInWindowViewModel viewModel = (SingInWindowViewModel)DataContext;
            viewModel.Done += ViewModel_Done;
        }

        private void ViewModel_Done(object sender, SingInWindowViewModel.DoneEventArgs e)
        {
            MessageBox.Show(e.Message);
        }
    }
}
