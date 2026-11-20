namespace TempMonitoring.Models
{
    public class SensorConfiguration
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
    }
}