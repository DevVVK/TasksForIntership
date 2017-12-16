using System.Data.Entity;
using UsersDAL.Entities;
using UsersDAL.Interfaces;
using UsersDAL.Repositories.BaseRepository;

namespace UsersDAL.Repositories
{
    public class PictureRepository : BaseRepository<Picture>, IRepository<Picture>
    {
        public PictureRepository()
        {
            Table = UserContext.Pictures;
        }

        public void Delete(int id)
        {
            UserContext.Entry(new Picture {Id = id}).State = EntityState.Deleted;
            SaveChanges();
        }
    }
}