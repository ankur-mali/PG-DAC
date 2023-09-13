using Microsoft.EntityFrameworkCore;
using System.Data;
using VCA.Models;
using VCA.Repositories;

namespace VCA.Services.Vehical
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _dbContext;

        public VehicleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Dictionary<string, object>>> FindCompByModelIdAsync(int modelId, char compType)
        {
            /* string query = "SELECT DISTINCT(comp_id), is_configurable, comp_type, comp_name " +
                            "FROM vehicles " +
                            "JOIN components ON vehicles.comp_id = components.id " +
                            "JOIN models ON vehicles.mod_id = @modelId " +
                            "WHERE vehicles.comp_type = @compType";*/

            var result = await _dbContext.Vehicles.Join(
                            _dbContext.Components,
                            vehicle => vehicle.comp_id,
                            component => component.Id,
                            (vehicle, component) => new { vehicle, component }
                            )
                        .Join(
                            _dbContext.Models,
                            combined => combined.vehicle.mod_id,
                            model => model.Id,
                            (combined, model) => new { combined.vehicle, combined.component, model }
                            )
                        .Where(combined => (char)combined.vehicle.CompType == compType && combined.model.Id == modelId)
                        .Select(combined => new
                            {
                            Id = combined.component.Id,
                            IsConfigurable = combined.vehicle.IsConfigurable,
                            CompType = combined.vehicle.CompType,
                            Comp_name = combined.component.CompName
                            })
                        .ToListAsync();



            var resultList = result.Select(item => new Dictionary<string, object>
                        {
                            { "comp_id", item.Id },
                            { "is_configurable", item.IsConfigurable.ToString() },
                            { "comp_type", item.CompType.ToString() },
                            { "comp_name", item.Comp_name }
                        }).ToList();

            return resultList;
        }
    }
}
