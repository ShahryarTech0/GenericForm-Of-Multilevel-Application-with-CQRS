using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Commands.UpdateMerchant
{
    public record UpdateMerchantCommand(int ID, string Name, int? ParentID, string? POCName, string? POCEmail) : IRequest<ApiResponse<MerchantLocationDto>>;
}
}
