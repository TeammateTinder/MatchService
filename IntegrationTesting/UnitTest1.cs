using MatchServiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace IntegrationTesting
{
    public class UnitTest1
    {

        //[Fact]
        //public void HttpRequestToProfileService()
        //{
        //    // Arrange
        //    //ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
        //    ConnectionFactory factory = new ConnectionFactory() { HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") };
        //    MatchService matchService = new MatchService(factory.CreateConnection());

        //    // Act
        //    matchService.AddIdToSwipedYes(0, 69420);

        //    // Assert

        //}

        [Fact]
        public void EasyTest()
        {
            // Arrange
            int a = 1;
            int b = 2;

            // Act
            int result = a + b;

            // Assert
            Assert.Equal(3, result);
        }
    }
}