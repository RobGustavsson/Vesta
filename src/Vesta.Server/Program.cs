using System;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Vesta.Server.Domain;

namespace Vesta.Server
{
    public static class WebHostExtensions
    {
        public static IWebHost Seed(this IWebHost host)
        {
            var customers = Enumerable
                .Range(0, 4)
                .Select(x =>
                {
                    var address = new Address("street", "town", x.ToString());
                    var customer = new Customer(
                        Guid.NewGuid(),
                        x,
                        new FullName($"First {x}", $"Last {x}"),
                        new Email($"email{x}"),
                        address);

                    var animal = customer.AddAnimal(
                        Guid.NewGuid(),
                        $"Animal {x}",
                        "gender",
                        x,
                        "exterior",
                        address,
                        "No history");

                    animal.AddJournal(
                        Guid.NewGuid(),
                        DateTime.Now,
                        "findings",
                        "work done",
                        "result",
                        "follow up",
                        "aftercare");

                    return customer;
                });

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                using var context = serviceProvider.GetService<Context>();

                context.AddRange(customers);
                context.SaveChanges();
            }

            return host;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .Seed()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

}
