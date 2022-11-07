using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AP.Model
{
    public class Product : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Polja
        private int _id;
        private string _nazivProizvoda;
        private decimal _cena;
        private string _opis;
        private string _trenkorisnik;
        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        #endregion
        #region Svojstva
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);

        }

        public int ID
        {
            get { return _id; }
            set
            {
                if (_id == value)
                {
                    return;
                }
                _id = value;

                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }
        public string NazivProizvoda
        {
            get { return _nazivProizvoda; }
            set
            {
                if (_nazivProizvoda == value)
                {
                    return;
                }
                _nazivProizvoda = value;

                List<string> errors = new List<string>();
                bool valid = true;

                if (value == null || value == "")
                {
                    errors.Add("User name can't be empty.");
                    SetErrors("NazivProizvoda", errors);
                    valid = false;
                }


                if (!Regex.Match(value, @"^[a-zA-Z]+$").Success)
                {
                    errors.Add("User name can only contain letters.");
                    SetErrors("NazivProizvoda", errors);
                    valid = false;
                }

                if (valid)
                {
                    ClearErrors("NazivProizvoda");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("NazivProizvoda"));
            }
        }
        public decimal Cena
        {
            get { return _cena; }
            set
            {
                if (_cena == value)
                {
                    return;
                }
                _cena = value;

                List<string> errors = new List<string>();
                bool valid = true;

                if (value <= -1)
                {
                    errors.Add("Price can't be negative.");
                    SetErrors("Cena", errors);
                    valid = false;
                }

                //if (!System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), "  ^ [0-9]"))
                //{
                //    errors.Add("Price can only be numbers.");
                //    SetErrors("Cena", errors);
                //    valid = false;
                //}
                if (valid)
                {
                    ClearErrors("Cena");
                }


                OnPropertyChanged(new PropertyChangedEventArgs("Cena"));
            }
        }
        public string Opis
        {
            get { return _opis; }
            set
            {
                if (_opis == value)
                {
                    return;
                }
                _opis = value;

                OnPropertyChanged(new PropertyChangedEventArgs("Opis"));
            }
        }
        public string TrenKorisnik
        {
            get { return ActiveUser.UserName; }
            set
            {
                if (ActiveUser.UserName == value)
                {
                    return;
                }
                _trenkorisnik = value;

                OnPropertyChanged(new PropertyChangedEventArgs("TrenKorisnik"));
            }
        }
        public bool HasErrors
        {
            get
            {
                return (errors.Count > 0);
            }
        }

        public Product(int id, string nazivProizvoda, decimal cena, string opis)
        {
            this.ID = id;
            this.NazivProizvoda = nazivProizvoda;
            this.Cena = cena;
            this.Opis = opis;
       
        }
        public Product()
        {
            NazivProizvoda = "";
            Cena = 0;
            Opis = "";
        }
        #endregion
        #region Data Acess
        public static Product GetProductFromResultSet(SqlDataReader reader)
        {
            Product product = new Product((int)reader["ID"], (string)reader["NazivProizvoda"], (decimal)reader["Cena"], (string)reader["Opis"]);
            return product;
        }

        public void DeleteProduct()
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                conn.Open();

                SqlCommand command = new SqlCommand("UPDATE Product SET is_deleted=1 WHERE ID=@ID", conn);

                SqlParameter myParam = new SqlParameter("@ID", SqlDbType.Int, 11);
                myParam.Value = this.ID;

                command.Parameters.Add(myParam);

                int rows = command.ExecuteNonQuery();

            }
        } 

        public void InsertProduct()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                conn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Product(NazivProizvoda, Cena, Opis, is_deleted) VALUES(@NazivProizvoda, @Cena, @Opis, 0); SELECT IDENT_CURRENT('Product');", conn);

                SqlParameter nazivProizvodaParam = new SqlParameter("@NazivProizvoda", SqlDbType.NVarChar);
                nazivProizvodaParam.Value = this.NazivProizvoda;

                SqlParameter cenaParam = new SqlParameter("@Cena", SqlDbType.Decimal);
                cenaParam.Value = this.Cena;

                SqlParameter opisParam = new SqlParameter("@Opis", SqlDbType.NVarChar);
                opisParam.Value = this.Opis;

                //SqlParameter opisPobednik = new SqlParameter("@TrenKorisnik", SqlDbType.NVarChar);
                //opisParam.Value = this.TrenKorisnik;

                command.Parameters.Add(nazivProizvodaParam);
                command.Parameters.Add(cenaParam);
                command.Parameters.Add(opisParam);

                var id = command.ExecuteScalar();

                if (id != null)
                {
                    this.ID = Convert.ToInt32(id);
                }

            }
        }
        public void Save()
        {
            if (ID == 0)
            {
                InsertProduct();
            }
        }

        #endregion
        #region Validacija, sinhronizacija
        private void SetErrors(string propertyName, List<string> propertyErrors)
        {
            errors.Remove(propertyName);
            errors.Add(propertyName, propertyErrors);
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void ClearErrors(string propertyName)
        {
            errors.Remove(propertyName);
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return (errors.Values);
            }
            else
            {
                if (errors.ContainsKey(propertyName))
                {
                    return (errors[propertyName]);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
    }
}
