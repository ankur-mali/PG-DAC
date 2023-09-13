using VCA.Repositories;

namespace VCA.Services.AlternateComponent
{



    public class AlternateComponentRepository : IAlternateComponentRepository
    {
        private readonly AppDbContext _dbContext;

        public AlternateComponentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Dictionary<string, object>>> FindByModelIdAndCompIdAsync(int modId, int compId)
        {
            /*            var queryResult = await _dbContext.AlternateComponents
                            .FromSqlRaw("SELECT c.id, c.comp_name FROM alternate_components a JOIN components c ON a.alt_comp_id = c.id WHERE a.mod_id = {0} AND a.comp_id = {1} AND a.comp_id <> a.alt_comp_id", modId, compId)
                            .ToListAsync();*/

            var queryResult = from a in _dbContext.AlternateComponents
                              join c in _dbContext.Components on a.AltComponentId equals c.Id
                              where a.ModId.Id == modId && a.ComponentId == compId && a.ComponentId != a.AltComponentId
                              select new
                              {
                                  Id = c.Id,
                                  comp_name = c.CompName,
                                  DeltaPrice = a.DeltaPrice
                              };

            // Convert the result to a list of dictionaries
            var resultList = queryResult.Select(result => new Dictionary<string, object>
            {
                { "id", result.Id },
                { "deltaPrice", result.DeltaPrice },
                { "comp_name", result.comp_name}
            }).ToList();

            return resultList;
        }
    }
}
