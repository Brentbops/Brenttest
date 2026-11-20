using TempMonitoring.Models;
using TempMonitoring.Services;

namespace TempMonitoring.Tests
{
    public class SensorManagerTests
    {
        [Fact]
        public void InitialiseSensor_ValidConfiguration_CreatesSensor()
        {
            // Arrange
            SensorManager manager = new SensorManager();

            SensorConfiguration configuration = new SensorConfiguration
            {
                Id = 1,
                Name = "Sensor 1",
                Location = "Server Room A"
            };

            // Act
            Sensor sensor = manager.InitialiseSensor(configuration);

            // Assert
            Assert.Equal(1, sensor.Id);
            Assert.Equal("Sensor 1", sensor.Name);
            Assert.Equal("Server Room A", sensor.Location);
            Assert.False(sensor.IsRunning);
        }

        [Fact]
        public void InitialiseSensor_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            SensorManager manager = new SensorManager();

            SensorConfiguration configuration = new SensorConfiguration
            {
                Id = 0,
                Name = "Sensor 1",
                Location = "Server Room A"
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                manager.InitialiseSensor(configuration));
        }

        [Fact]
        public void InitialiseSensor_MissingName_ThrowsArgumentException()
        {
            // Arrange
            SensorManager manager = new SensorManager();

            SensorConfiguration configuration = new SensorConfiguration
            {
                Id = 1,
                Name = "",
                Location = "Server Room A"
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                manager.InitialiseSensor(configuration));
        }

        [Fact]
        public void InitialiseSensor_MissingLocation_ThrowsArgumentException()
        {
            // Arrange
            SensorManager manager = new SensorManager();

            SensorConfiguration configuration = new SensorConfiguration
            {
                Id = 1,
                Name = "Sensor 1",
                Location = ""
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                manager.InitialiseSensor(configuration));
        }

        [Fact]
        public void InitialiseSensor_DuplicateId_ThrowsArgumentException()
        {
            // Arrange
            SensorManager manager = new SensorManager();

            SensorConfiguration firstSensor = new SensorConfiguration
            {
                Id = 1,
                Name = "Sensor 1",
                Location = "Server Room A"
            };

            SensorConfiguration duplicateSensor = new SensorConfiguration
            {
                Id = 1,
                Name = "Sensor 2",
                Location = "Server Room B"
            };

            manager.InitialiseSensor(firstSensor);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                manager.InitialiseSensor(duplicateSensor));
        }
    }
}