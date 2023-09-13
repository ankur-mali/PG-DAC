using Microsoft.EntityFrameworkCore;
using VCA.Models;
using VCA.Repositories;

namespace VCA.Services.Verient

{
    public class ModelRepository : IModelRepository
    {
        private readonly AppDbContext _dbContext;

        public ModelRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Model>> FindByManufacturerIdAndSegmentIdAsync(int manuId, int segId, int page = 1, int pageSize = 10)
        {
            return await _dbContext.Models
                .Where(m => m.ManuId == manuId && m.SegId == segId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(m => m.Manufacturer) // Include the Manufacturer navigation property
                .Include(m => m.Segment) // Include the Segment navigation property
                .ToListAsync();
        }

        public async Task<List<Model>> FindAllByOrderByCreatedAtDescAsync(int page = 1, int pageSize = 10)
        {
            return await _dbContext.Models
                .OrderByDescending(m => m.created_at)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(m => m.Manufacturer) // Include the Manufacturer navigation property
                .Include(m => m.Segment) // Include the Segment navigation property
                .ToListAsync();
        }

        public async Task<Model> FindModelByIdAsync(int id)
        {
            // Assuming you have a DbSet<Model> in your AppDbContext called "Models"
            // You can use Entity Framework's FindAsync method to retrieve a model by its ID
            var model = await _dbContext.Models.FindAsync(id);

            return model;
        }
    }

}
