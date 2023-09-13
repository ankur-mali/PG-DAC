using VCA.Models;

namespace VCA.Services.Manufaturers
{
    public interface IManufacturerRepository
    {
        Task<List<Manufacturer>> GetManufacturersBySegmentIdAsync(int segId);
    }
}
