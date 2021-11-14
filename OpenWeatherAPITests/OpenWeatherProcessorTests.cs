using OpenWeatherAPI;
using System;
using Xunit;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        //ce commentaire est juste pour changer quelque chose pour le commit
        OpenWeatherProcessor OWP = OpenWeatherProcessor.Instance;

        [Fact]
        public async void GetOneCallAsync_IfAPIKeyEmptyOrNull_ThrowArgumentException()
        {
            //Arrange
            OWP.ApiKey = null;
            //Act
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(OWP.GetOneCallAsync);
            Assert.Contains("ApiKey null or empty!", ex.Message);
        }

        [Fact]
        public async void GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            //Arrange
            OWP.ApiKey = null;
            //Act
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(OWP.GetCurrentWeatherAsync);
            Assert.Contains("ApiKey null or empty!", ex.Message);
        }
        [Fact]
        public async void GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            //Arrange
            OWP.ApiKey = "ADWE"; 
            //Act
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(OWP.GetOneCallAsync);
            Assert.Contains("ApiClient not initialized!", ex.Message);
        }
        [Fact]
        public async void GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            //Arrange
            OWP.ApiKey = "ADWE"; //matter pas trop si on le fait ou pas vu que c'est un singleton
            //Act
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(OWP.GetOneCallAsync);
            Assert.Contains("ApiClient not initialized!", ex.Message);
        }
    }
}
