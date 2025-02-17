using Microsoft.EntityFrameworkCore;
using SOS.PersistenceLayer;

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
                UserInterface ui = new UserInterface(context);
                ui.Run(); // Gọi giao diện để chạy chương trình
            }
        }
    }
}
