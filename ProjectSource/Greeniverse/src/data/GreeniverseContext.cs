using Greeniverse.src.models;
using Microsoft.EntityFrameworkCore;

namespace Greeniverse.src.data
{
    public class GreeniverseContext : DbContext
    {
        
        public DbSet<UserModel> User { get; set; }
        public DbSet<StockModel> Stock { get; set; }
        public DbSet<ShoppingCartModel> ShoppingCart { get; set; }

        public GreeniverseContext(DbContextOptions<GreeniverseContext> opt) : base(opt)
        {

        }

    }
}
