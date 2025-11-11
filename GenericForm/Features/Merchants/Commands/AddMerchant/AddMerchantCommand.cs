using MerchantApplication.Features.Merchants.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Commands.AddMerchant
{
    public record AddMerchantCommand(string MerchantName, string MerchantAddress, string? Email, string? OtherEmail, string? Number) : IRequest<ApiResponse<MerchantDto>>;
}
