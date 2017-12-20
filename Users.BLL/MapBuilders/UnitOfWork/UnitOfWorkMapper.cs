namespace Users.BLL.MapBuilders.UnitOfWork
{
    public class UnitOfWorkMapper
    {
        private MapUser _mapUser;

        private MapUserDto _mapUserDto;

        public MapUser MapUser => _mapUser ?? (_mapUser = new MapUser());

        public MapUserDto MapUserDto => _mapUserDto ?? (_mapUserDto = new MapUserDto());
    }
}