using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodedHome.Model;

namespace CodeHome.Data
{
    public class ApplicationUnit : IDisposable
    {
        private readonly DataContext _context = new DataContext();
        private IRepository<Home> _homes = null;
        private IRepository<User> _users = null;

        public IRepository<Home> Homes
        {
            get { return _homes ?? (_homes = new GenericRepository<Home>(_context)); }
        }

        public IRepository<User> Users
        {
            get { return _users ?? (_users = new GenericRepository<User>(_context)); }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        } 

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
