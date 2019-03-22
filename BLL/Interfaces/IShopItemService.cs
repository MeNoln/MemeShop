using BLL.DataTransferObjects;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IShopItemService
    {
        IEnumerable<DTOShopItem> GetAll();
        DTOShopItem Get(int? id);
        void Create(DTOShopItem model);
        void Delete(int id);
        void Edit(DTOShopItem model);
        void Dispose();
    }
}
