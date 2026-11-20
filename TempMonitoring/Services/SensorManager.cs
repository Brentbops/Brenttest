using TempMonitoring.Models;

namespace TempMonitoring.Services
{
    public class SensorManager
    {
        private readonly List<Sensor> _sensors = new();

        public Sensor InitialiseSensor(SensorConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (configuration.Id <= 0)
                throw new ArgumentException("Sensor ID must be greater than zero.");

            if (string.IsNullOrWhiteSpace(configuration.Name))
                throw new ArgumentException("Sensor name is required.");

            if (string.IsNullOrWhiteSpace(configuration.Location))
                throw new ArgumentException("Sensor location is required.");
            if (_sensors.Any(s => s.Id == configuration.Id))
                throw new ArgumentException("A sensor with this ID already exists.");


            Sensor sensor = new Sensor
            {
                Id = configuration.Id,
                Name = configuration.Name,
                Location = configuration.Location,
                IsRunning = false
            };

            _sensors.Add(sensor);

            return sensor;
        }
    }
}


