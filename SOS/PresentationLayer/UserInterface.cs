using System;
using System.Text;
using SOS.BusinessLayer;
using SOS.Models;
using SOS.PersistenceLayer;
using Microsoft.EntityFrameworkCore;

namespace SOS.PresentationLayer
{
    public class UserInterface
    {
        private readonly CustomerObject _customerObject;

        public UserInterface(AppDbContext context)
        {
            _customerObject = new CustomerObject(context);
        }

        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8; // Đảm bảo hỗ trợ tiếng Việt

            while (true)
            {
                Console.WriteLine("\n🔹 Chọn chức năng:");
                Console.WriteLine("1️⃣ Thêm khách hàng");
                Console.WriteLine("2️⃣ Xem danh sách khách hàng");
                Console.WriteLine("3️⃣ Thêm đơn hàng");
                Console.WriteLine("4️⃣ Xem đơn hàng của khách hàng");
                Console.WriteLine("5️⃣ Thoát");
                Console.Write("🔸 Lựa chọn: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        ListCustomers();
                        break;
                    case "3":
                        AddOrder();
                        break;
                    case "4":
                        ListOrders();
                        break;
                    case "5":
                        Console.WriteLine("👋 Chương trình kết thúc. Hẹn gặp lại!");
                        return;
                    default:
                        Console.WriteLine("⚠️ Lựa chọn không hợp lệ. Vui lòng nhập lại!");
                        break;
                }
            }
        }

        private void AddCustomer()
        {
            Console.Write("📝 Nhập tên khách hàng: ");
            string name = Console.ReadLine();
            _customerObject.AddCustomer(new Customer { Name = name });
            Console.WriteLine("✅ Khách hàng đã được thêm thành công!");
        }

        private void ListCustomers()
        {
            var customers = _customerObject.GetAllCustomers();
            Console.WriteLine("\n📌 Danh sách khách hàng:");
            customers.ForEach(c => Console.WriteLine($"🔹 ID: {c.Id}, Tên: {c.Name}"));
        }

        private void AddOrder()
        {
            Console.Write("📌 Nhập ID khách hàng: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("📝 Nhập mô tả đơn hàng: ");
            string details = Console.ReadLine();
            _customerObject.PlaceOrder(new Order { CustomerId = customerId, OrderDetails = details });
            Console.WriteLine("✅ Đơn hàng đã được thêm thành công!");
        }

        private void ListOrders()
        {
            Console.Write("📌 Nhập ID khách hàng: ");
            int customerId = int.Parse(Console.ReadLine());
            var orders = _customerObject.GetCustomerOrders(customerId);
            Console.WriteLine("\n📌 Danh sách đơn hàng:");
            orders.ForEach(o => Console.WriteLine($"🛒 ID: {o.Id}, Chi tiết: {o.OrderDetails}"));
        }
    }
}
