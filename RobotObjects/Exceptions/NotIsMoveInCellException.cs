using System;

namespace RobotObjects.Exceptions
{
    /// <summary>
    /// Класс представляющий исключение не проходимой ячейки
    /// </summary>
    public class NotIsMoveInCellException : Exception
    {
        public NotIsMoveInCellException() : base($"Данная ячейка не проходима")
        { }
    }
}