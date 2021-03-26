using ECommerce.Domain.DomainHelpers;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ECommerce.Infrastructure.Data
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ECommerceDbContext(serviceProvider.GetRequiredService<DbContextOptions<ECommerceDbContext>>()))
            {
                if (context.Smartphones.Any()) return;

                context.Manufacturers.AddRange(
                    new Manufacturer("Samsung"),
                    new Manufacturer("Apple")
                    );
                context.SaveChanges();

                context.Smartphones.AddRange(
                    new Smartphone("iPhone 12",
                    context.Manufacturers.First(x => x.Name == "Apple"),
                    6,
                    164,
                    new ScreenResolution(1170, 2532),
                    4,
                    "Apple A14 Bionic",
                    "iOS 14.1",
                    781.99m));




                //new Smartphone()
                //{
                //    Name = "iPhone 12",
                //    OperatingSystem = "iOS 14.1",
                //    Processor = "Apple A14 Bionic",
                //    Size = 6,
                //    ScreenWidth = 1170,
                //    Manufacturer = context.Manufacturers.First(x => x.Name == "Apple"),
                //    Ram = 4,
                //    ScreenHeight = 2532,
                //    Price = 781.99m,
                //    Weight = 164
                //},
                //new Smartphone
                //{
                //    Name = "iPhone 12 Pro",
                //    OperatingSystem = "iOS 14.1",
                //    Processor = "Apple A14 Bionic",
                //    Manufacturer = context.Manufacturers.First(x => x.Name == "Apple"),
                //    Size = 6,
                //    Ram = 6,
                //    ScreenWidth = 1170,
                //    ScreenHeight = 2532,
                //    Price = 1022m,
                //    Weight = 189
                //},
                //new Smartphone
                //{
                //    Name = "iPhone 12 Pro Max",
                //    OperatingSystem = "iOS 14.1",
                //    Processor = "Apple A14 Bionic",
                //    Size = 7,
                //    Manufacturer = context.Manufacturers.First(x => x.Name == "Apple"),
                //    Ram = 6,
                //    ScreenWidth = 1284,
                //    ScreenHeight = 2778,
                //    Price = 1200m,
                //    Weight = 228
                //},
                //new Smartphone
                //{
                //    Name = "Samsung Galaxy S20",
                //    OperatingSystem = "Android 10",
                //    Processor = "Exynos 990",
                //    Size = 6,
                //    Manufacturer = context.Manufacturers.First(x => x.Name == "Samsung"),
                //    Ram = 8,
                //    ScreenWidth = 1440,
                //    ScreenHeight = 3200,
                //    Price = 1200m,
                //    Weight = 163
                //},
                //new Smartphone
                //{
                //    Name = "Samsung Galaxy S20",
                //    OperatingSystem = "Android 10",
                //    Processor = "Exynos 990",
                //    Manufacturer = context.Manufacturers.First(x => x.Name == "Samsung"),
                //    Size = 6,
                //    Ram = 8,
                //    ScreenWidth = 1440,
                //    ScreenHeight = 3200,
                //    Price = 1200m,
                //    Weight = 163
                //},
                //new Smartphone
                //{
                //    Name = "Samsung Galaxy S20",
                //    OperatingSystem = "Android 10",
                //    Processor = "Exynos 990",
                //    Manufacturer = context.Manufacturers.First(x => x.Name == "Samsung"),
                //    Size = 7,
                //    Ram = 8,
                //    ScreenWidth = 1440,
                //    ScreenHeight = 3200,
                //    Price = 1440m,
                //    Weight = 186
                //},
                //new Smartphone
                //{
                //    Name = "Samsung Galaxy S20",
                //    OperatingSystem = "Android 10",
                //    Processor = "Qualcomm SM8250 Snapdragon 865",
                //    Size = 7,
                //    Ram = 12,
                //    ScreenWidth = 1440,
                //    ScreenHeight = 3200,
                //    Price = 1540m,
                //    Weight = 222
                //}
                //); 
                context.SaveChanges();
            }
        }
    }
}
