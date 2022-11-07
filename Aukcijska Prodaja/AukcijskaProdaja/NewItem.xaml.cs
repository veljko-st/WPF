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
    /// Interaction logic for NewItem.xaml
    /// </summary>
    public partial class NewItem : Window
    {
        public NewItem()
        {
            InitializeComponent();
        }

        private void rectangle_Loaded(object sender, RoutedEventArgs e)
        {
            NewItemViewModel viewModel = (NewItemViewModel)DataContext;
            viewModel.Done += ViewModel_Done;
        }

        private void ViewModel_Done(object sender, NewItemViewModel.DoneEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
