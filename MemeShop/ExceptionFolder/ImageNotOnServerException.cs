﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.ExceptionFolder
{
    //If user trying to find image that doesn't exist on server send this exception
    public class ImageNotOnServerException : Exception
    {
        public string Property { get; set; }
        public ImageNotOnServerException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}