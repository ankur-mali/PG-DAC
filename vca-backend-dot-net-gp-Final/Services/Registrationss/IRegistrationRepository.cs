using VCA.Models;

namespace VCA.Services.Registrations
{
    public interface IRegistrationRepository
    {
        Task<Registration> FindByUsernameAsync(string email);
        Task<Registration> CreateRegistrationAsync(Registration reg);
        Task<Registration> GetRegistrationByIdAsync(int id);
    }
}
