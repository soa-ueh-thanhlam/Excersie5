using SOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.PersistenceLayer
{
    public class OrderDAO
    {
        private readonly AppDbContext _context;

        public OrderDAO(AppDbContext context)
        {
            _context = context;

            // Đảm bảo CSDL và bảng được tạo
            _context.Database.EnsureCreated();
        }

        public List<Order> GetOrdersByCustomer(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
