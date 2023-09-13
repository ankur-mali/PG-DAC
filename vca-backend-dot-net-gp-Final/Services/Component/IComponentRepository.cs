using VCA.Models;

namespace VCA.Repositories
{
    public interface IComponentRepository
    {
        Task<List<Component>> GetAllComponentsAsync();
        Task<Component> GetComponentByIdAsync(int id);
        Task<Component> CreateComponentAsync(Component component);
        Task<Component> UpdateComponentAsync(int id, Component component);
        Task DeleteComponentAsync(int id);
    }
}

