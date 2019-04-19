using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.ExceptionFolder
{
    //If user sent to server nothing send this exception
    public class EmptyFileException : Exception
    {
        public string Property { get; set; }
        public EmptyFileException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}