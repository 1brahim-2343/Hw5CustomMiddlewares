namespace Hw5CustomMiddlewares.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Capacity { get; set; }
        public double MaxSpeed { get; set; }
        public int Range { get; set; }
        public bool IsOperational { get; set; }
        public DateTime ManufactureTime { get; set; }
    }
}
