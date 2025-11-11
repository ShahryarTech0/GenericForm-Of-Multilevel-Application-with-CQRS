using MerchantApplication.Features.Merchants.Commands.AddMerchant;
using MerchantApplication.Features.Merchants.Commands.DeleteMerchant;
using MerchantApplication.Features.Merchants.Commands.UpdateMerchant;
using MerchantApplication.Features.Merchants.Dto;
using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Mapping
{
    public class MerchantMappingProfile :Profile
    {
        public MerchantMappingProfile()
        {
            CreateMap<AddMerchantCommand, Merchant>().ReverseMap();
            CreateMap<UpdateMerchantCommand, Merchant>().ReverseMap();
            CreateMap<DeleteMerchantCommand, Merchant>().ReverseMap();
            CreateMap<Merchant, MerchantDto>();
        }
    }
}
