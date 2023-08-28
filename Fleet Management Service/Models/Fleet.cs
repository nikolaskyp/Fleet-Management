using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Fleet_Management_Service.Models
{
    public class Fleet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fleet name is required")]
        public string Name { get; set; }
        public List<Vessel> Vessels { get; set; } = new List<Vessel>();
    }

}
