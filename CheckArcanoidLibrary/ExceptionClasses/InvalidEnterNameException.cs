using System;

namespace CheckArcanoidLibrary.ExceptionClasses
{
    public class InvalidEnterNameException : Exception
    {
        public InvalidEnterNameException() : base("Заполните данное поле") { }
    }
}