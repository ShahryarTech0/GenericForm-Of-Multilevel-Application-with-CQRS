using MerchantApplication.Features.Merchants.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Queries.GetAllMerchant
{
    public record GetAllMerchantQuery() : IRequest<ApiResponse<IEnumerable<MerchantDto>>>;
}
