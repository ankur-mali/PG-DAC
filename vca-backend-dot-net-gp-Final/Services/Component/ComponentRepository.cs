using Microsoft.EntityFrameworkCore;
using VCA.Models;

namespace VCA.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly AppDbContext _dbContext;

        public ComponentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Component>> GetAllComponentsAsync()
        {
            return await _dbContext.Components.ToListAsync();
        }

        public async Task<Component> GetComponentByIdAsync(int id)
        {
            return await _dbContext.Components.FindAsync(id);
        }

        public async Task<Component> CreateComponentAsync(Component component)
        {
            _dbContext.Components.Add(component);
            await _dbContext.SaveChangesAsync();
            return component;
        }

        public async Task<Component> UpdateComponentAsync(int id, Component component)
        {
            var existingComponent = await _dbContext.Components.FindAsync(id);
            if (existingComponent == null)
                return null;

            existingComponent.CompName = component.CompName;



            await _dbContext.SaveChangesAsync();
            return existingComponent;
        }

        public async Task DeleteComponentAsync(int id)
        {
            var componentToDelete = await _dbContext.Components.FindAsync(id);
            if (componentToDelete != null)
            {
                _dbContext.Components.Remove(componentToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

