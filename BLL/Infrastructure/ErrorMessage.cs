using System;

namespace BLL.Infrastructure
{
    //Error message class, to show what's wrong
    public class ErrorMessage : Exception
    {
        public string Property { get; protected set; }
        public ErrorMessage(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
