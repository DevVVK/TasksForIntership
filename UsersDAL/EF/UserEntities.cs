using UsersDAL.Entities;

namespace UsersDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UserEntities : DbContext
    {
        public UserEntities() : base("name=UsersConnection")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}