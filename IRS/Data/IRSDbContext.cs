using Microsoft.EntityFrameworkCore;

namespace IRS.Data
{
    public class IRSDbContext : DbContext
    {

        private readonly string _connectionString;

        /*public IRSDbContext(DbContextOptions<IRSDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _connectionString = configuration.GetConnectionString("IRSDbConnect");
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1KLCRTE;Database=IRSDB_1;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        public DbSet<IRS.Models.Cook> Cooks { get; set; }
        public DbSet<IRS.Models.Deliverer> Deliverers { get; set; }
        public DbSet<IRS.Models.Host> Hosts { get; set; }
        public DbSet<IRS.Models.Manager> Managers { get; set; }
        public DbSet<IRS.Models.Order> Orders { get; set; }
        public DbSet<IRS.Models.Product> Products { get; set; }
        public DbSet<IRS.Models.StorageItem> StorageItems { get; set; }
        public DbSet<IRS.Models.Table> Tables { get; set; }
        public DbSet<IRS.Models.ToGoOrder> ToGoOrders { get; set; }
        public DbSet<IRS.Models.Waiter> Waiters { get; set; }
        
    }
}
