using AP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace AP.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {   //ova klasa sluzi za prikazivane podataka u listbox iz tabele Product, brisanje podataka i cuvanje
        #region Polja
        private Product currentProduct;
        private ProductCollection productList;
        private ListCollectionView productListView;
        private string filteringText;
        private ICommand deleteCommand;
        private Mediator mediator;
        private User currentUser;
        private UserCollection userList;
        private ListCollectionView userListView;

        private ActiveUser currentActiveUser;
        #endregion
        #region Svojstva
        public Product CurrentProduct
        {
            get { return currentProduct; }
            set
            {
                if (currentProduct == value)
                {
                    return;
                }
                currentProduct = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentProduct"));
            }
        }
        public ProductCollection ProductList
        {
            get { return productList; }
            set
            {
                if (productList == value)
                {
                    return;
                }
                productList = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductList"));
            }
        }
        public ListCollectionView ProductListView
        {
            get { return productListView; }
            set
            {
                if (productListView == value)
                {
                    return;
                }
                productListView = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductListView"));
            }
        }
        public String FilteringText
        {
            get { return filteringText; }
            set
            {
                if (filteringText == value)
                {
                    return;
                }
                filteringText = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FilteringText"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
            set
            {
                if (deleteCommand == value)
                {
                    return;
                }
                deleteCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DeleteCommand"));
            }
        }
        void DeleteExecute(object obj)
        {
            currentProduct.DeleteProduct();
            productList.Remove(currentProduct);
        }

        bool CanDelete(object obj)
        {
            if (currentProduct == null) return false;

            return true;
        }
        public User Currentuser
        {
            get { return currentUser; }
            set
            {
                if (currentUser == value)
                {
                    return;
                }
                currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Currentuser"));
            }
        }
        public UserCollection UserList
        {
            get { return userList; }
            set
            {
                if (userList == value)
                {
                    return;
                }
                userList = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserList"));
            }
        }
        public ListCollectionView UserListView
        {
            get { return userListView; }
            set
            {
                if (userListView == value)
                {
                    return;
                }
                userListView = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserListView"));
            }
        }


        public ActiveUser CurrenActivetuser
        {
            get { return currentActiveUser; }
            set
            {
                if (currentActiveUser == value)
                {
                    return;
                }
                currentActiveUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Currentuser"));
            }
        }
        #endregion
        //Ovde imam problem kod ucitavanja liste
        #region Constructor
        public MainWindowViewModel(Mediator mediator)//Mediator mediator
        {
            
            this.mediator = mediator;
           
           // mediator.Register("ProductChange", ProductChanged);
            DeleteCommand = new RelayCommand(DeleteExecute, CanDelete);
            this.PropertyChanged += MainWindowViewModel_PropertyChanged;

            ProductList = ProductCollection.GetAllProduct();
            ProductListView = new ListCollectionView(ProductList);

            productListView.Filter = ProductFilter;
            CurrentProduct = new Product();



            UserList = UserCollection.GetAllUsers();
            Currentuser = new User();
            UserListView = new ListCollectionView(UserList);

            


            //CurrenActivetuser = ActiveUser();
            //ActiveUserListView = new ListCollectionView(CurrenActivetuser);
        }

        private void ProductChanged(object sender)
        {
            Product product = (Product)sender;

            int index = ProductList.IndexOf(product);

            if (index != -1)
            {
                ProductList.RemoveAt(index);
                ProductList.Insert(index, product);
            }
            else
            {
                ProductList.Add(product);
            }
        }

        private void MainWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("FilteringText"))
            {
                ProductListView.Refresh();
            }
        }   

        private bool ProductFilter(object obj)
        {
            if (FilteringText == null)
            {
                return true;
            }
            if (FilteringText == "")
            {
                return true;
            }
            Product product = obj as Product;
            return(product.NazivProizvoda.ToLower().StartsWith(FilteringText.ToLower()));
        }
        #endregion
    }
}
