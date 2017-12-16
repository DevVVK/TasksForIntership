using System.Data.Entity;
using UsersDAL.Entities;
using UsersDAL.Interfaces;
using UsersDAL.Repositories.BaseRepository;

namespace UsersDAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IRepository<User>
    {
        public UserRepository()
        {
            Table = UserContext.Users;
        }

        public void Delete(int id)
        {
            UserContext.Entry(new User {Id = id}).State = EntityState.Deleted;
            SaveChanges();
        }
    }
}