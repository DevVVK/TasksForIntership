using System.Collections.ObjectModel;
using Logon.Users.Data.MapBuilders;
using Users.BLL.Services;

namespace Logon.Users.Data.Managed
{
    /// <summary>
    /// Класс обновления данных в списке наблюдаемой коллекции объектов
    /// </summary>
    /// <typeparam name="TItems">тип объектов хранящихся в коллекции</typeparam>
    /*public class ObservableCollectionUpdater<TItems>
    {
        private ObservableCollection<TItems> _collection; 

        private MapUserDto _dataMapper;

        public ObservableCollectionUpdater(ObservableCollection<TItems> collection)
        {
            _collection = collection;
        }

        public void Update()
        {
            _collection.Clear();

            using (var dataBase = new UserService())
            {
                _collection.Add(default(TItems));
            }
        }

        public 
    }*/
}