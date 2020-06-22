using Microsoft.EntityFrameworkCore;
using SPA_Angular_Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPA_Angular_Core.DAL.Repositories
{
    public class CarShopContext: DbContext
    {
        public CarShopContext(DbContextOptions<CarShopContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }
    }
}
