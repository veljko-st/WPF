using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Model
{
    public class UserCollection : ObservableCollection<User>
    {
        #region GetAllUsers
        public static UserCollection GetAllUsers()
        {
            UserCollection users = new UserCollection();
            User user = null;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT ID, UserName, UserPass, Status FROM Users ", conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = User.GetUserFromResultSet(reader);
                        users.Add(user);
                    }
                }
            }
            return users;
        }
        #endregion
    }
}
