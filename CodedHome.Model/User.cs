﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedHome.Model
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
