using Fleet_Management_Service.Models;
using Fleet_Management_Service.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleet_Management_Service.Services
{
    public class FleetService
    {
        // Dependency injection for the database context and constractor
        private readonly AppDbContext _dbContext;

        public FleetService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Retries all fleets along with their assigned vessels
        public async Task<List<Fleet>> GetFleetsAsync()
        {
            return await _dbContext.Fleets.Include(f => f.Vessels).ToListAsync();
        }
        //creates a fleets and saves it on the satabase
        public async Task CreateFleetAsync(Fleet fleet)
        {
            _dbContext.Fleets.Add(fleet);
            await _dbContext.SaveChangesAsync();
        }
        //Updates the existing data in the database
        public async Task UpdateFleetAsync(Fleet fleet)
        {
            _dbContext.Fleets.Update(fleet);
            await _dbContext.SaveChangesAsync();
        }
        //deletes fleets based on the id
        public async Task DeleteFleetAsync(int id)
        {
            var fleet = await _dbContext.Fleets.FindAsync(id);
            _dbContext.Fleets.Remove(fleet);
            await _dbContext.SaveChangesAsync();
        }
    }
}
