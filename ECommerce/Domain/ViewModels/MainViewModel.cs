using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Services;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private readonly IRepository<Product> _productRepo;
        private readonly ProductService _productService;

        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set { filterText = value; OnPropertyChanged(); }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged(); }
        }


        public bool IsLower { get; set; } = false;

        public RelayCommand ToLowerCommand { get; set; }
        public RelayCommand SelectProductCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }

        public MainViewModel(IRepository<Product> productRepo)
        {
            SearchText = String.Empty;
            FilterText = "Higher To Lower";
            _productRepo = productRepo;
            _productService = new ProductService();

            SelectedProduct = new Product();

            AllProducts = _productRepo.GetAllData();


            SearchCommand = new RelayCommand((o) =>
            {
                AllProducts = new ObservableCollection<Product>(_productRepo.GetAllData().Where(p=>p.Name.ToLower().Contains(SearchText.ToLower()) || p.Name==String.Empty));
            });

            ToLowerCommand = new RelayCommand((o) =>
            {
                if (!IsLower)
                {
                    FilterText = "Lower To Higher";
                }
                else
                {
                    FilterText = "Higher To Lower";
                }
                IsLower = !IsLower;
                AllProducts = _productService.GetFromLowerToHigher(IsLower);
            });



            SelectProductCommand = new RelayCommand((o) =>
            {
                var vm = new ProductInfoViewModel();
                vm.ProductInfo = SelectedProduct;

                var view = new ProductWindow();
                view.DataContext = vm;

                view.ShowDialog();
            });

        }

    }
}
