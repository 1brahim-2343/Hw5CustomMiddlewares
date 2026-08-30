using System.ComponentModel.DataAnnotations;

namespace Hw5CustomMiddlewares.DTOs
{
    public class AirplaneAddDto
    {
        [Required]
        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Range(1,900)]
        public int Capacity { get; set; }
        [Range(1,1000)]
        public double MaxSpeed { get; set; }
        [Range(1,10000)]
        public int Range { get; set; }
        public bool IsOperational { get; set; }
        public DateOnly ManufactureDate { get; set; }
    }
}
