namespace RobotObjects.Objects.Base
{
    /// <summary>
    /// Базовый класс для классов эмулятора передвижения робота
    /// </summary>
    public class BaseRobot
    {
        #region Открытые свойства

        /// <summary>
        /// Ширина объекта 
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Высота объекта
        /// </summary>
        public double Height { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор для инициализатора объекта
        /// </summary>
        public BaseRobot()
        {
            
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="width">ширина объекта</param>
        /// <param name="height">высота объекта</param>
        public BaseRobot(double width, double height)
        {
            Width = width;
            Height = height;
        }

        #endregion
    }
}