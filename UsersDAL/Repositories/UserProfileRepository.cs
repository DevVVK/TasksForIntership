using System.Data.Entity;
using UsersDAL.Entities;
using UsersDAL.Interfaces;
using UsersDAL.Repositories.BaseRepository;

namespace UsersDAL.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IRepository<UserProfile>
    {
        public UserProfileRepository()
        {
            Table = UserContext.UserProfiles;
        }

        public void Delete(int id)
        {
            UserContext.Entry(new UserProfile {Id = id}).State = EntityState.Deleted;
            SaveChanges();
        }
    }
}