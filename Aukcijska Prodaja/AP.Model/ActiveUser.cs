using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Model
{
    public class ActiveUser //: INotifyPropertyChanged
    {
        #region Polja
        private static string userName;
        #endregion
        #region Svojstva
        public static string UserName
        {
            get { return userName; }
            set {
                if (userName == value)
                {
                    return;
                }
                userName = value;
               
            }
        }
        #endregion

        //private static string userstatus;
        //public static string UserStatus
        //{
        //    get { return userstatus; }
        //    set
        //    {
        //        if (userstatus == value)
        //        {
        //            return;
        //        }
        //        userstatus = value;

        //    }
        //}
        //public event PropertyChangedEventHandler PropertyChanged;      
        //public void OnPropertyChanged(PropertyChangedEventArgs e)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, e);

        //}
        //private string _status;
        //public  string Status
        //{
        //    get { return _status; }
        //    set
        //    {
        //        _status = userstatus;
        //        OnPropertyChanged(new PropertyChangedEventArgs("Status"));
        //    }
        //}
        //public ActiveUser(string status)
        //{
        //    this.Status = status;
        //}
        //public ActiveUser()
        //{
        //    UserStatus = "spectator";
        //}
        ////public static ActiveUser GetActiveUserFromResultSet(SqlDataReader reader)
        ////{
        ////    ActiveUser user = new ActiveUser((string)reader["Status"]);
        ////    return user;
        ////}
        //public override string ToString()
        //{
        //    return UserStatus;
        //}
    }
}
