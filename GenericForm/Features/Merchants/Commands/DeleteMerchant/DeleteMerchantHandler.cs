using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Commands.DeleteMerchant
{
    internal class DeleteMerchantHandler
    {
    }
    public class DeleteMerchantHandler : IRequestHandler<DeleteMerchantCommand, ApiResponse<string>>
    {
        private readonly IMapper _mapper;
        private readonly IMerchantRepository _merchantRepository;
        private readonly ILogger<DeleteMerchantHandler> _logger;
        public DeleteMerchantHandler(IMapper mapper, IMerchantRepository merchantRepository, ILogger<DeleteMerchantHandler> logger)
        {
            _mapper = mapper;
            _merchantRepository = merchantRepository;
            _logger = logger;
        }
        public async Task<ApiResponse<string>> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _merchantRepository.GetByID(request.id);
                if (result == null)
                {
                    _logger.LogWarning("Location not found for deletion. Id={Id}", request.id);
                    return ApiResponse<string>.Fail("0", $"Location with id {request.id} not found.");
                }
                // Option A: Hard delete
                await _merchantRepository.DeleteAsync(result);

                // Option B: Soft delete
                // await _merchantLocationRepository.SoftDeleteAsync(result);

                _logger.LogInformation("Merchant Location with ID {Id} deleted successfully.", request.id);
                return ApiResponse<string>.Success($"Merchant Location with ID {request.id} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Merchant Location with ID {Id}", request.id);
                return ApiResponse<string>.Fail("0", "An error occurred while deleting the location.");
            }
        }
    }
}
