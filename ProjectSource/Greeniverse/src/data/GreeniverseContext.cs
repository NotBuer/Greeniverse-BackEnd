using Greeniverse.src.models;
using Microsoft.EntityFrameworkCore;

namespace Greeniverse.src.data
{
    /// <summary>
    /// <para>Resume: Context class, responsible for loading context and define DbSets</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 13/05/2022</para>
    /// </summary>
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
