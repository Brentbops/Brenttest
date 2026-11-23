namespace TempMonitoring.Models
{
    public class Sensor
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public bool IsRunning { get; set; }
    }
}
