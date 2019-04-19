using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces.UoWPattern;
using System.Collections.Generic;

/// <summary>
/// Discount codes service with using Automapper
/// </summary>
namespace BLL.Services
{
    //Discount code service class to work with
    public class DiscountCodeService : IDiscountCodeService
    {
        //Pattern initialise
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

        //Using AutoMapper to map DTO object with DAL
        public IEnumerable<DTODiscountCode> GetAllCodes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DiscountCode, DTODiscountCode>()).CreateMapper();
            return mapper.Map<IEnumerable<DiscountCode>, List<DTODiscountCode>>(uowDiscount.DiscountRepository.GetAllCodes());
        }

        //IDisposable pattern
        public void Dispose()
        {
            uowDiscount.Dispose();
        }
    }
}
