using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Queries.GetMerchantbyId
{
    public record GetMerchantbyIdQuery(int Id) : IRequest<ApiResponse<MerchantDto>>;
}
