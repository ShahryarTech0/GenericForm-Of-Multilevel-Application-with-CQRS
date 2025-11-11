using MerchantApplication.Features.Merchants.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Queries.GetMerchantbyId
{
    internal class GetAllMerchantbyIdHandler
    {
    }
    public class GetAllMerchantbyIdHandler : IRequestHandler<GetMerchantbyIdQuery, ApiResponse<MerchantDto>>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMerchantbyIdHandler> _logger;

        public GetMerchantbyIdHandler(IMerchantRepository merchantRepository, IMapper mapper, ILogger<GetMerchantbyIdHandler> logger)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
            _logger = logger;


        }
        public async Task<ApiResponse<MerchantDto>> Handle(GetMerchantbyIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Get areas from repository
                var zones = await _merchantRepository.GetByID(request.Id);

                if (zones == null)
                {
                    _logger.LogInformation("Areas not found for Zone ID {ZoneID}", request.Id);
                    return ApiResponse<MerchantDto>.Fail("0", "Invalid merchantLocation data");
                }

                _logger.LogInformation("Areas fetched successfully for Zone ID {ZoneID}", request.Id);
                var dto = _mapper.Map<MerchantDto>(zones);
                return ApiResponse<MerchantDto>.Success(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching areas for Zone ID {ZoneID}", request.Id);
                return ApiResponse<MerchantDto>.Fail("400", "An error occurred while Getting the merchantlocation.");
            }
        }

    }
}
