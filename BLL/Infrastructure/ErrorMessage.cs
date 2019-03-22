using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class ErrorMessage : Exception
    {
        public string Property { get; protected set; }
        public ErrorMessage(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
