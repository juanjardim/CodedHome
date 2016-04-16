using System.Data.Entity;
using CodedHome.Model;

namespace CodeHome.Data
{
    public class HomesRepository : GenericRepository<Home>
    {
        public HomesRepository(DbContext context) : base(context)
        {
        }
    }
}
