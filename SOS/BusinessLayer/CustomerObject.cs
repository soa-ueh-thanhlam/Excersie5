using SOS.Models;
using SOS.PersistenceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.BusinessLayer
{
    public class CustomerObject
    {
        private readonly CustomerDAO _customerDao;
        private readonly OrderDAO _orderDao;

        public CustomerObject(AppDbContext context)
        {
            _customerDao = new CustomerDAO(context);
            _orderDao = new OrderDAO(context);
        }

        public List<Customer> GetAllCustomers() => _customerDao.GetCustomers();

        public void AddCustomer(Customer customer) => _customerDao.AddCustomer(customer);

        public List<Order> GetCustomerOrders(int customerId) => _orderDao.GetOrdersByCustomer(customerId);

        public void PlaceOrder(Order order) => _orderDao.AddOrder(order);
    }
}
