using AgaroAPI.Data;
using AgaroAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgaroAPI.Respositry
{
    public class LocationMasterRepository : ILocationMasterRepository
    {
        private readonly AgaroDbContext dbContext;
        public LocationMasterRepository(AgaroDbContext dbContext)
        {
                this.dbContext = dbContext;
        }

        public async Task<LocationMaster> CreateAsync(LocationMaster locationMaster)
        {
            await dbContext.LocationMasters.AddAsync(locationMaster);
            await dbContext.SaveChangesAsync();
            return locationMaster;
        }

        public async Task<LocationMaster> DeleteAsync(Guid id)
        {
            var locations = await dbContext.LocationMasters.FirstOrDefaultAsync(x => x.Id == id);
            if (locations == null) { return null; }
            dbContext.LocationMasters.Remove(locations);
            await dbContext.SaveChangesAsync();
            return locations;
        }

        public async Task<List<LocationMaster>> GetAllAsync()
        {
            return await dbContext.LocationMasters.ToListAsync();
        }

        public async Task<LocationMaster> GetById(Guid id)
        {
           return await dbContext.LocationMasters.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<LocationMaster> UpdateAsync(Guid id, LocationMaster locationMaster)
        {
          var locations=  await dbContext.LocationMasters.FirstOrDefaultAsync(x => x.Id == id);
            if (locations == null) { return null; }
            locations.LocationName = locationMaster.LocationName;
            locations.LocationCode = locationMaster.LocationCode;

            await dbContext.SaveChangesAsync();
            return locations;
        }
    }
}

