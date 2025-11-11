using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Commands.DeleteMerchant
{
    public record DeleteMerchantCommand(int id) : IRequest<ApiResponse<string>>;
}
