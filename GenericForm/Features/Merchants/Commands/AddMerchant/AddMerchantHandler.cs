using MerchantApplication.Features.Merchants.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Commands.AddMerchant
{
    public class AddMerchantHandler : IRequestHandler<AddMerchantCommand, ApiResponse<MerchantDto>>
    {
        private readonly IMerchantRepository _repositoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddMerchantHandler> _logger;

        public AddMerchantHandler(IMerchantRepository repositoryRepository, IMapper mapper, ILogger<AddMerchantHandler> logger)
        {
            _repositoryRepository = repositoryRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ApiResponse<MerchantDto>> Handle(AddMerchantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Map command to entity
                var merchantEntity = _mapper.Map<Merchant>(request);


                // Optional: validate ParentID
                //if (merchant.ParentID.HasValue && merchant.ParentID.Value > 0) // 1 and 1>0
                //{
                //    var parentZone = await _repositoryRepository.GetZoneByID(merchant.ParentID.Value);//Parent location is null
                //    if (parentZone == null)
                //    {
                //        _mapper.Map<MerchantDto>(merchant);

                //        return ApiResponse<MerchantDto>.Fail("0", "ParentId Doesnot Exist merchant");

                //    }
                //}

                if (merchantEntity == null)
                {
                    return ApiResponse<MerchantDto>.Fail("0", "Invalid merchant data.");
                }
                // Add location
                var added = await _repositoryRepository.AddAsync(merchant);
                var result = _mapper.Map<MerchantDto>(merchant);
                return ApiResponse<MerchantDto>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding merchant location.");
                return ApiResponse<MerchantDto>.Fail("0", "An error occurred while adding the merchant.");
            }
        }
    }
}
