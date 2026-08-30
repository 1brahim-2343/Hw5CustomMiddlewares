namespace Hw5CustomMiddlewares.DTOs
{
    public class AirplaneDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Capacity { get; set; }
        public double MaxSpeed { get; set; }
        public int Range { get; set; }
        public bool IsOperational { get; set; }
        public DateOnly ManufactureDate { get; set; }
        public int AirplaneAge { get; set; }
    }
}
