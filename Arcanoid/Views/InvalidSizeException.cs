using System;

namespace Arcanoid.Views
{
    public class InvalidSizeException : Exception
    {
        public InvalidSizeException() : base($"Размещение блоков невозможно")
        {
            
        }
    }
}