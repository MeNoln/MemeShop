using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.ExceptionFolder
{
    public class InvalidFileException : Exception
    {
        public string Property { get; set; }
        public InvalidFileException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}