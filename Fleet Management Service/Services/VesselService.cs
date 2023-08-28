using Fleet_Management_Service.Models;
using Fleet_Management_Service.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleet_Management_Service.Services
{
    public class VesselService
    {
        // Dependency injection for the database context and constractor
        private readonly AppDbContext _dbContext;

        public VesselService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Retries all vessels along with their assigned containers
        public async Task<List<Vessel>> GetVesselsAsync()
        {
            var result = await _dbContext.Vessels.Include(v => v.Containers).ToListAsync();  
            return result;
        }

        //Fetches a vessel by its id
        public async Task<Vessel> GetVesselByIdAsync(int id)
        {
            return await _dbContext.Vessels.FindAsync(id);
        }

        //Registers a Vessel to the database
        public async Task CreateVesselAsync(Vessel vessel)
        {
            _dbContext.Vessels.Add(vessel);
            await _dbContext.SaveChangesAsync();
        }
        //Updates existing vessels in the database
        public async Task UpdateVesselAsync(Vessel vessel)
        {
            _dbContext.Vessels.Update(vessel);
            await _dbContext.SaveChangesAsync();
        }
        //Deletes Vessels by their id's
        public async Task DeleteVesselAsync(int id)
        {
            var vessel = await _dbContext.Vessels.FindAsync(id);
            _dbContext.Vessels.Remove(vessel);
            await _dbContext.SaveChangesAsync();
        }
    }
}
