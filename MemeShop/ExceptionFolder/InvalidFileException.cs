using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.ExceptionFolder
{
    //If file type is incorrect send this exception
    public class InvalidFileException : Exception
    {
        public string Property { get; set; }
        public InvalidFileException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}