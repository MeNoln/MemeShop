using DAL.Entities;
using DAL.Interfaces.IDiscountRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.UoWPattern
{
    public interface IUoWDIscount : IDisposable
    {
        IDiscountRepo<DiscountCode> DiscountRepository { get; }
        void Save();
    }
}
