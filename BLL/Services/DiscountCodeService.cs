using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces.UoWPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DiscountCodeService : IDiscountCodeService
    {
        IUoWDIscount uowDiscount { get; set; }
        public DiscountCodeService(IUoWDIscount uowDiscount)
        {
            this.uowDiscount = uowDiscount;
        }

        public void Create(DTODiscountCode context)
        {
            DiscountCode model = new DiscountCode { Code = context.Code, DiscountPerCent = context.DiscountPerCent};
            uowDiscount.DiscountRepository.Create(model);
        }

        public void Delete(int id)
        {
            uowDiscount.DiscountRepository.Delete(id);
        }

        public IEnumerable<DTODiscountCode> GetAllCodes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DiscountCode, DTODiscountCode>()).CreateMapper();
            return mapper.Map<IEnumerable<DiscountCode>, List<DTODiscountCode>>(uowDiscount.DiscountRepository.GetAllCodes());
        }
    }
}
