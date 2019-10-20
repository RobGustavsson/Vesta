using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Vesta.Server.Domain;

namespace Vesta.Server.Schema
{
    public class Query
    {
        public async Task<IReadOnlyList<Customer>> GetCustomers([Service] Context dbContext)
        {
            return await dbContext
                .Customers
                .OrderBy(x => x.Number)
                .Include(x => x.Animals)
                .ThenInclude(x => x.Journals)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomer(long number, [Service] Context dbContext)
        {
            return await dbContext
                .Customers
                .Include(c => c.Animals)
                .ThenInclude(a => a.Journals)
                .SingleOrDefaultAsync(x => x.Number == number);
        }
    }
}
