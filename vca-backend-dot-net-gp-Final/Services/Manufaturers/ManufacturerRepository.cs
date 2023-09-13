using Microsoft.EntityFrameworkCore;
using VCA.Models;
using VCA.Repositories;

namespace VCA.Services.Manufaturers
{

    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly AppDbContext _dbContext;

        public ManufacturerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Manufacturer>> GetManufacturersBySegmentIdAsync(int segId)
        {
            return await _dbContext.Manufacturers
                .Where(m => m.SegId == segId)
                .ToListAsync();
        }
    }
}
