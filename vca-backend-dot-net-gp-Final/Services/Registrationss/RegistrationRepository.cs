using Microsoft.EntityFrameworkCore;
using VCA.Models;
using VCA.Repositories;

namespace VCA.Services.Registrations
{


    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _dbContext;

        public RegistrationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Registration> FindByEmailAsync(string email)
        {
            return await _dbContext.Registrations.FirstOrDefaultAsync(r => r.Email == email);
        }

        public async Task<Registration> FindByUsernameAsync(string email)
        {
            return await _dbContext.Registrations.FirstOrDefaultAsync(r => r.Email == email);
        }

        public async Task<Registration> CreateRegistrationAsync(Registration reg)
        {
            _dbContext.Registrations.Add(reg);
            await _dbContext.SaveChangesAsync();
            return reg;
        }

        public async Task<Registration> GetRegistrationByIdAsync(int id)
        {
            // Implementation for GetRegistrationByIdAsync
            // Retrieve a Registration by its ID using EF Core
            return await _dbContext.Registrations.FindAsync(id);
        }

    }
}
