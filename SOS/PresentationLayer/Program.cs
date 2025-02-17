using SOS.BusinessLayer;
using SOS.Models;
using SOS.PersistenceLayer;
using System;
using Microsoft.EntityFrameworkCore;


namespace SOS.PresentationLayer
{
    class Program
    {
        static void Main()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=localhost;Database=MYAPP;Trusted_Connection=True;")
                .Options;

            using (var context = new AppDbContext(options))
            {
                CustomerObject customerObject = new CustomerObject(context);

                while (true)
                {
                    Console.WriteLine("\nChọn chức năng:");
                    Console.WriteLine("1. Thêm khách hàng");
                    Console.WriteLine("2. Xem danh sách khách hàng");
                    Console.WriteLine("3. Thêm đơn hàng");
                    Console.WriteLine("4. Xem đơn hàng của khách hàng");
                    Console.WriteLine("5. Thoát");
                    Console.Write("Lựa chọn: ");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Console.Write("Nhập tên khách hàng: ");
                        string name = Console.ReadLine();
                        customerObject.AddCustomer(new Customer { Name = name });
                        Console.WriteLine("✔ Khách hàng đã được thêm.");
                    }
                    else if (choice == "2")
                    {
                        var customers = customerObject.GetAllCustomers();
                        Console.WriteLine("\nDanh sách khách hàng:");
                        customers.ForEach(c => Console.WriteLine($"ID: {c.Id}, Tên: {c.Name}"));
                    }
                    else if (choice == "3")
                    {
                        Console.Write("Nhập ID khách hàng: ");
                        int customerId = int.Parse(Console.ReadLine());
                        Console.Write("Nhập mô tả đơn hàng: ");
                        string details = Console.ReadLine();
                        customerObject.PlaceOrder(new Order { CustomerId = customerId, OrderDetails = details });
                        Console.WriteLine("✔ Đơn hàng đã được thêm.");
                    }
                    else if (choice == "4")
                    {
                        Console.Write("Nhập ID khách hàng: ");
                        int customerId = int.Parse(Console.ReadLine());
                        var orders = customerObject.GetCustomerOrders(customerId);
                        Console.WriteLine("\nDanh sách đơn hàng:");
                        orders.ForEach(o => Console.WriteLine($"ID: {o.Id}, Chi tiết: {o.OrderDetails}"));
                    }
                    else if (choice == "5")
                    {
                        break;
                    }
                }
            }
        }
    }
}
