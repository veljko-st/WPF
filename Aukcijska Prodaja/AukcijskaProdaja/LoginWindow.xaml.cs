using AP.Model;
using AP.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            //MainWindowViewModel mainWindowView = new MainWindowViewModel(Mediator.Instance);
            //this.DataContext = mainWindowView;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            using (SqlConnection conn = new SqlConnection())
            {

                List<ActiveUser> users = new List<ActiveUser>();
                ActiveUser user = null;

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM Users WHERE UserName=@UserName AND UserPass=@UserPass", conn);
                //SqlCommand command2 = new SqlCommand("SELECT Status FROM Users WHERE UserName=@UserName AND UserPass=@UserPass", conn);

                command.Parameters.AddWithValue("@UserName", txtUsername.Text);
                command.Parameters.AddWithValue("@UserPass", txtpassword.Password);

                //command2.Parameters.AddWithValue("@UserName", txtUsername.Text);
                //command2.Parameters.AddWithValue("@UserPass", txtpassword.Password);


                //using (SqlDataReader reader = command2.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        user = new ActiveUser((string)reader["Status"]);
                //        users.Add(user);
                //        ActiveUser.UserStatus= user.ToString();
                //    }
                //}

                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 1)
                {
                    ActiveUser.UserName = txtUsername.Text;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("Login failed. Please try again.");
                }
            }
        }
        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            SingInWindow singInWindow = new SingInWindow();
            singInWindow.DataContext = new SingInWindowViewModel(Mediator.Instance);
            singInWindow.ShowDialog();
        }
    }
}
