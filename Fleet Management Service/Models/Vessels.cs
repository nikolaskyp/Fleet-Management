using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fleet_Management_Service.Models
{
    public class Vessel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "IMO Number is required.")]
        [RegularExpression(@"\d{7}", ErrorMessage = "IMO Number must be exactly 7 digits.")]
        public string IMONumber { get; set; }

        [Required(ErrorMessage = "Maximum Capacity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0 for Maximum Capacity.")]
        public int MaximumCapacity { get; set; }
        public List<Container> Containers { get; set; }

        public int? FleetId { get; set; }
        public Fleet Fleet { get; set; }
    }

}
