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

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}