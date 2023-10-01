using AgaroAPI.Data;
using AgaroAPI.Model.Domain;
using AgaroAPI.Model.DTOs;
using AgaroAPI.Respositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgaroAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly AgaroDbContext dbContext;
        private readonly ILocationMasterRepository locationMaster;
        public LocationsController(AgaroDbContext dbContext, ILocationMasterRepository locationMaster)
        {
            this.dbContext = dbContext;
            this.locationMaster = locationMaster;
        }
        // Get All Method
        // Get https://localhost:7007/api/locations
        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            // Get Data From Domain Models
            var locationsdomain = await locationMaster.GetAllAsync();

            // Map Domain Model in to DTO
            var locationdto = new List<LocationMasterDto>();
            foreach (var locations in locationsdomain)
            {
                locationdto.Add(new LocationMasterDto()
                {
                    Id = locations.Id,
                    LocationName = locations.LocationName,
                    LocationCode = locations.LocationCode,
                });
            }
            return Ok(locationdto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LocationMasterDto addlocation)
        {
            // convert dto to domain model
            var locationdto = new LocationMaster
            {
                LocationCode = addlocation.LocationCode,
                LocationName = addlocation.LocationName,
            };

            // domain model using for creating location
            locationdto = await locationMaster.CreateAsync(locationdto);
            return CreatedAtAction(nameof(GetById), new { id = locationdto.Id }, locationdto);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var locations = await locationMaster.GetById(id);
            if (locations == null)
            {
                return NotFound();
            }
            return Ok(locations);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] LocationMasterDto updateloaction)
        {
            // convert domain to DTO
            var locdto = new LocationMaster
            {
                Id = updateloaction.Id,
                LocationCode = updateloaction.LocationCode,
                LocationName = updateloaction.LocationName,
            };

            locdto = await locationMaster.UpdateAsync(id, locdto);
            return Ok(locdto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var locationdto = await locationMaster.DeleteAsync(id);
            var locdto = new LocationMasterDto
            {
                Id = locationdto.Id,
                LocationCode = locationdto.LocationCode,
                LocationName = locationdto.LocationName,
            };
            return Ok(locdto);
        }
    }
}


