namespace VCA.Services.AlternateComponent
{
    public interface IAlternateComponentRepository
    {
        Task<List<Dictionary<string, object>>> FindByModelIdAndCompIdAsync(int modId, int compId);
    }
}