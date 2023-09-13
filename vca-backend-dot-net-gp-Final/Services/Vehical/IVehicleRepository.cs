namespace VCA.Services.Vehical
{
    public interface IVehicleRepository
    {
        Task<List<Dictionary<string, object>>> FindCompByModelIdAsync(int modelId, char compType);

    }
}