namespace Users.BLL.MapBuilders.UnitOfWork
{
    /// <summary>
    /// Класс UnitOfWork(единица работы) обьединяющий все классы отображения данных (mappers)
    /// </summary>
    public class UnitOfWorkMapper
    {
        #region Закрытые поля

        /// <summary>
        /// Поле объекта см. <see cref="MapUser"/>
        /// </summary>
        private MapUser _mapUser;

        /// <summary>
        /// Поле объекта см. <see cref="MapUserDto"/>
        /// </summary>
        private MapUserDto _mapUserDto;

        #endregion

        #region Открытые свойства

        /// <summary>
        /// Свойство возвращающее объект <see cref="MapUser"/>
        /// </summary>
        public MapUser MapUser => _mapUser ?? (_mapUser = new MapUser());

        /// <summary>
        /// Свойство возвращающее объект <see cref="MapUserDto"/>
        /// </summary>
        public MapUserDto MapUserDto => _mapUserDto ?? (_mapUserDto = new MapUserDto());

        #endregion
    }
}