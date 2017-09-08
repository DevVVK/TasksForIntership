using System;

namespace CheckArcanoidLibrary.ExceptionClasses
{
    public class InvalidSizeException : Exception
    {
        public InvalidSizeException() : base("Не хватает места на игровом поле") { }
    }
}