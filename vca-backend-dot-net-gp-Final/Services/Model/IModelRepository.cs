using VCA.Models;
namespace VCA.Services.Verient


{
    public interface IModelRepository
    {
        Task<List<Model>> FindByManufacturerIdAndSegmentIdAsync(int manuId, int segId, int page = 1, int pageSize = 10);

        Task<List<Model>> FindAllByOrderByCreatedAtDescAsync(int page = 1, int pageSize = 10);
        
        Task<Model> FindModelByIdAsync(int id);
    }
}
