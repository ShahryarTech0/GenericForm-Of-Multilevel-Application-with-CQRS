using MerchantCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Interface
{
    public interface IMerchantLocationRepository
    {
        Task<Merchant> AddAsync(Merchant entity);

        Task<Merchant> GetZoneByID(int id);

        Task<Merchant> UpdateZoneAsync(Merchant entity);

        Task<Merchant> DeleteAsync(Merchant entity);

        Task<IEnumerable<Merchant>> GetAllZonesAsync();

    }
}
