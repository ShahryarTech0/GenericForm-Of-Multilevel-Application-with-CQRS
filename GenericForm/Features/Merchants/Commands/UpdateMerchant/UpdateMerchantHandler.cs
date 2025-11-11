using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Commands.UpdateMerchant
{
    internal class UpdateMerchantHandler
    {
    }
    public class UpdateMerchantHandler : IRequestHandler<UpdateMerchantCommand, ApiResponse<MerchantDto>>
    {

        private readonly IMerchantRepository _repositoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddMerchantHandler> _logger;

        public UpdateMerchantHandler(IMerchantRepository repositoryRepository, IMapper mapper, ILogger<AddMerchantHandler> logger)
        {
            _repositoryRepository = repositoryRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ApiResponse<MerchantDto>> Handle(UpdateMerchantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existing = await _repositoryRepository.GetByID(request.ID);
                if (existing == null)
                {
                    _logger.LogWarning("Merchant location not found for update. Id={Id}", request.ID);
                    return ApiResponse<MerchantDto>.Fail("0", $"Merchant location with ID {request.ID} not found.");
                }

                // Map updated fields from the command to the entity
                _mapper.Map(request, existing);

                // Optional: handle logical conditions if needed
                //if (request.IsDeleted)
                //{
                //    existingLocation.Status = "Inactive";
                //}

                var result = await _repositoryRepository.UpdateAsync(existing);
                _logger.LogInformation("Merchant with ID {Id} updated successfully.", request.ID);

                var dto = _mapper.Map<MerchantDto>(result);
                return ApiResponse<MerchantDto>.Success(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating merchant ID {Id}", request.ID);
                return ApiResponse<MerchantDto>.Fail("0", $"Error updating merchant : {ex.Message}");
            }
        }
    }
