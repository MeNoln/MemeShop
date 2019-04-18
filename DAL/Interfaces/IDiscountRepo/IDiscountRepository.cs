using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.IDiscountRepo
{
    public interface IDiscountRepo<T> where T : class
    {
        IEnumerable<T> GetAllCodes();
        void Create(T context);
        void Delete(int id);
    }
}
