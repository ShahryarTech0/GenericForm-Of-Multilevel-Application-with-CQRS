using MerchantInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MerchantInfrastructure.MerchantRepositories.MerchantRepository;

namespace MerchantInfrastructure.MerchantRepositories
{
    public class MerchantRepository : IMerchantRepository
    {
            private readonly AppDbContext _context;
            public MerchantRepository(AppDbContext context)
            {
                _context = context;
            }
            public async Task<Merchant?> GetByID(int id)
            {

                return await _context.MerchantLocations
                                     .Include(l => l.Merchant) // optional: include merchant info
                                     .FirstOrDefaultAsync(l => l.ID == id);
            }

            public async Task<Merchant> AddAsync(Merchant entity)
            {
                await _context.MerchantLocations.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            public async Task<Merchant?> DeleteAsync(Merchant entity)
            {
                _context.MerchantLocations.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            public async Task<Merchant> UpdateAsync(Merchant entity)
            {
                _context.MerchantLocations.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            public async Task<IEnumerable<Merchant?>> GetAllAsync()
            {
                return await _context.MerchantLocations
                                     .Include(l => l.Merchant) // optional
                                     .ToListAsync();
            }


        }
    }
}
