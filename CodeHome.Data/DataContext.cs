using System.Configuration;
using System.Data.Entity;
using CodedHome.Model;
using CodeHome.Data.Configuration;

namespace CodeHome.Data
{
    public class DataContext : DbContext
    {
        public DataContext() :base(DataContext.ConnectionStringName) {}
        public DbSet<Home> Homes { get; set; }
        public DbSet<User> Users { get; set; }

        public static string ConnectionStringName
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionStringName"] ?? "DefaultConnection";
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HomeConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
