using AgaroAPI.Model.Domain;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace AgaroAPI.Respositry
{
    public interface ILocationMasterRepository
    {
        Task<List<LocationMaster>> GetAllAsync();
        Task<LocationMaster> GetById(Guid id);
        Task<LocationMaster> CreateAsync(LocationMaster locationMaster);
        Task<LocationMaster> UpdateAsync(Guid id, LocationMaster locationMaster);
        Task<LocationMaster> DeleteAsync(Guid id);
    }
}
