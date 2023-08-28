using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fleet_Management_Service.Models
{
    public class Container
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Container ID is required")]
        public string ContainerId { get; set; }
        [Required(ErrorMessage = "Container Weight is required")]
        public int Weight { get; set; }
        public int VesselId { get; set; }
        public Vessel Vessel { get; set; }
    }

}
