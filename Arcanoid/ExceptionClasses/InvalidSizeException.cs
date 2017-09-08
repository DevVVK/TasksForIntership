using System;

namespace Arcanoid.ExceptionClasses
{
    public class InvalidSizeException : Exception
    {
        public InvalidSizeException() : base("Размещение блоков невозможно") { }
    }
}