using System.Data.Entity;
using CodedHome.Model;

namespace CodeHome.Data
{
    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(DbContext context) : base(context)
        {
        }
    }
}