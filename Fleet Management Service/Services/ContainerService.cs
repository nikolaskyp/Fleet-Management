using Fleet_Management_Service.Models;
using Fleet_Management_Service.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleet_Management_Service.Services
{
    public class ContainerService
    {
        // Dependency injection for the database context
        private readonly AppDbContext _context;

        public ContainerService(AppDbContext context)
        {
            _context = context;
        }
        // Gets all containers with with their associated vessels
        public async Task<List<Container>> GetContainersAsync()
        {
            return await _context.Containers.Include(c => c.Vessel).ToListAsync();
        }
        // Adds a new container and checks if it exceeds the vessel MaximimCapacity
        public async Task<(bool, string)> AddContainerAsync(Container container)
        {
            //find the Vessel
            var vessel = await _context.Vessels
                        .Include(v => v.Containers)
                        .FirstOrDefaultAsync(v => v.Id == container.VesselId);

            if (vessel == null)
            {
                return (false, "Vessel not found.");
            }
            //Calculate the total weight of all containers assign to a vessel
            int currentWeight = vessel.Containers.Sum(c => c.Weight);
            // Check if the container weight exceed the total weight
            if (currentWeight + container.Weight > vessel.MaximumCapacity)
            {
                return (false, "Cannot add the container since it exceeds the vessels Maximum Capacity.");
            }

            _context.Containers.Add(container);
            await _context.SaveChangesAsync();
            return (true, "Container added successfully.");
        }

        //updates container information
        public async Task UpdateContainerAsync(Container container)
        {
            _context.Containers.Update(container);
            await _context.SaveChangesAsync();
        }
        //deletes container ifnroamtion
        public async Task DeleteContainerAsync(int id)
        {
            var container = await _context.Containers.FindAsync(id);
            if (container != null)
            {
                _context.Containers.Remove(container);
                await _context.SaveChangesAsync();
            }
        }
    }

}


