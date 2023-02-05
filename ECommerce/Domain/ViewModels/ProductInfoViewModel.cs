using ECommerce.DataAccess.SqlServer;
using ECommerce.DataAccess.SqlServer.Repository;
using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    public class ProductInfoViewModel:BaseViewModel
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Order> _orderRepo;
        private readonly CustomerService _customerService;

        public ProductInfoViewModel()
        {
            _productRepo = new ProductRepository();
            _orderRepo = new OrderRepository();
            _customerService = new CustomerService();

            ProductInfo = new Product();

        }

        private Product productInfo;

        public Product ProductInfo
        {
            get { return productInfo; }
            set { productInfo = value; OnPropertyChanged(); }
        }

    }
}
