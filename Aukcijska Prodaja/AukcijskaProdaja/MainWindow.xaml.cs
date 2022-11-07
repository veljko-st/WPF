using AP.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AukcijskaProdaja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        ActiveUser user = new ActiveUser();
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mainViewModel = new MainWindowViewModel(Mediator.Instance);
            this.DataContext = mainViewModel;           
            timer.Tick += new EventHandler(Timer_tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            
            //labelStatus.Content = ActiveUser.UserStatus;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            NewItem newItem = new NewItem();
            newItem.DataContext = new NewItemViewModel(Mediator.Instance);
            newItem.ShowDialog();
            offerBtn.IsEnabled = true;                 
        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Name.Content = ActiveUser.UserName;
        }
        #region Offer
        int tick = 120;
        private void Timer_tick(object sender, EventArgs e)
        {
            tick--;
            labelTicker.Content = tick.ToString();

            if (tick == 0)
            {
                timer.Stop();               
                MessageBox.Show($"Auction for item {NazivProizvoda1.Content} is over \n Sold of price of {CenaSad.Text}.\n Winner is {Name.Content}");
                offerBtn.IsEnabled=false;
            }
        }
        private void RestartTimer()
        {
            tick = 120;
            timer.Start();
        }
        static decimal i = 1;

        private void offerBtn_Click(object sender, RoutedEventArgs e)
        {
            RestartTimer();
            timer.Start();           
            CenaSad.Text = (Convert.ToDecimal(Cena.Text) + i).ToString();      
            i++;
        }
        #endregion
        #region Status
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            offerBtn.IsEnabled = true;
            deleteBtn.IsEnabled = true;
            newProductBtn.IsEnabled = true;
        }

        private void UserBtn_Checked(object sender, RoutedEventArgs e)
        {
            deleteBtn.IsEnabled = false;
            newProductBtn.IsEnabled = false;
            offerBtn.IsEnabled = true;
        }

        private void SpectatorBtn_Checked(object sender, RoutedEventArgs e)
        {
            offerBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
            newProductBtn.IsEnabled = false;
        }
        #endregion
    }
}
