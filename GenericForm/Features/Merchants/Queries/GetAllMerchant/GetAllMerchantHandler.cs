using MerchantApplication.Features.Merchants.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Queries.GetAllMerchant
{
    public class GetAllMerchantHandler : IRequestHandler<GetAllMerchantQuery, ApiResponse<IEnumerable<MerchantDto>>>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllMerchantHandler> _logger;
        public GetAllMerchantHandler(IMerchantRepository merchantRepository, IMapper mapper, ILogger<GetAllMerchantHandler> logger)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse<IEnumerable<MerchantDto>>> Handle(GetAllMerchantQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var merchants = await _merchantRepository.GetAllAsync();
                if (merchants == null)
                {
                    return ApiResponse<IEnumerable<MerchantDto>>.Fail("0", "No Record");
                }
                var dtos = _mapper.Map<IEnumerable<MerchantDto>>(merchants);
                return ApiResponse<IEnumerable<MerchantDto>>.Success(dtos);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error fetching merchant.");
                return ApiResponse<IEnumerable<MerchantDto>>.Fail("0", "Error fetching merchant.");
            }

        }
    }
}
