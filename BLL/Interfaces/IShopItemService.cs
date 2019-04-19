using BLL.DataTransferObjects;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    //Shop items service Interface
    public interface IShopItemService
    {
        IEnumerable<DTOShopItem> GetAll();
        DTOShopItem Get(int? id);
        void Create(DTOShopItem model);
        void Delete(int id);
        void Edit(DTOShopItem model);

        //IDisposable pattern(realised in DAL UoW class)
        void Dispose();
    }
}
