using ECommerce.DataAccess.SqlServer;
using ECommerce.DataAccess.SqlServer.Repository;
using ECommerce.Domain.Abstractions;
using System.Linq;

namespace ECommerce
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepo;
        public CustomerService()
        {
            _customerRepo = new CustomerRepository();
        }

        public Customer GetCustomerByUsername(string username)
        {
            var customer = _customerRepo.GetAllData().FirstOrDefault(c => c.Username == username);
            return customer;
        }
    }
}