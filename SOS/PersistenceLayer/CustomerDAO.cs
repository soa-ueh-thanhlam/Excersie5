using SOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.PersistenceLayer
{
    public class CustomerDAO
    {
        private readonly AppDbContext _context;

        public CustomerDAO(AppDbContext context)
        {
            _context = context;

            // Đảm bảo CSDL và bảng được tạo
            _context.Database.EnsureCreated();
        }

        public List<Customer> GetCustomers() => _context.Customers.ToList();

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
