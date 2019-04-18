using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DataTransferObjects
{
    public class DTODiscountCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountPerCent { get; set; }
    }
}
