using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Interfaces;
using MemeShop.Models.DiscountCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemeShop.Controllers.Admin
{
    public class DiscountCodesHelper
    {
        IDiscountCodeService discountService { get; set; }
        public DiscountCodesHelper(IDiscountCodeService discountService)
        {
            this.discountService = discountService;
        }

        public DiscountMultupleViewModel MapDiscountVMWithDTO()
        {
            return map();
        }

        private DiscountMultupleViewModel map()
        {
            IEnumerable<DTODiscountCode> code = discountService.GetAllCodes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DTODiscountCode, DiscountCodeViewModel>()).CreateMapper();
            var map = mapper.Map<IEnumerable<DTODiscountCode>, List<DiscountCodeViewModel>>(code);
            DiscountMultupleViewModel model = new DiscountMultupleViewModel { CodesEnum = map };

            return model;
        }
    }
}