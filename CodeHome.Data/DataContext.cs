using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodedHome.Model;

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
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"];
                }
                return "DefaultConnection";
            }
        }
    }
}
