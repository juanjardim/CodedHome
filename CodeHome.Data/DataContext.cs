using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using CodedHome.Model;
using CodeHome.Data.Configuration;

namespace CodeHome.Data
{
    public class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer(new CustomerDatabaseInitializer());
        }

        public DataContext() :base(ConnectionStringName) {}

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

        public override int SaveChanges()
        {
            ApplyRules();
            return base.SaveChanges();
        }

        private void ApplyRules()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(
                    e => e.Entity is IAuditInfo &&
                         (e.State == EntityState.Added) ||
                         (e.State == EntityState.Modified)
                ))
            {
                IAuditInfo e = (IAuditInfo) entry.Entity;
                var currentDateTime = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    e.CreatedOn = currentDateTime;
                }
                e.ModifiedOn = currentDateTime;
            }
        }
    }
}
