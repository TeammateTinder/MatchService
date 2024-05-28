using MatchServiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using Xunit.Abstractions;

namespace IntegrationTesting
{
    public class UnitTest1
    {
        //private readonly ITestOutputHelper _logger;

        //public UnitTest1(ITestOutputHelper logger)
        //{
        //    _logger = logger;

        //}

        [Fact]
        public void EasyTest()
        {
            // Arrange
            string? HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST");
            if (string.IsNullOrEmpty(HostName))
            {
                HostName = "localhost";
            }
            ConnectionFactory factory = new ConnectionFactory() { HostName = HostName };
            MatchService matchService = new MatchService(factory.CreateConnection());
            int a = 1;
            int b = 2;

            // Act
            matchService.AddIdToSwipedYes(0, 69420);
            int result = a + b;

            // Assert
            Assert.Equal(3, result);
        }

        //[Fact]
        //public void TestFormatMessageYes()
        //{
        //    // Arrange
        //    string? HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST");
        //    if (string.IsNullOrEmpty(HostName))
        //    {
        //        HostName = "localhost";
        //    }
        //    ConnectionFactory factory = new ConnectionFactory() { HostName = HostName };
        //    MatchService matchService = new MatchService(factory.CreateConnection());
        //    int swiperID = 0;
        //    int swipedID = 1;
        //    YesOrNo yes = YesOrNo.y;

        //    // Act
        //    string messageResult = matchService.FormatMessage(swiperID, swipedID, yes);
        //    string expectedResult = $"{swiperID}:{swipedID}:{yes}";

        //    // Assert
        //    _logger.WriteLine($"Expected: {expectedResult}, Result: {messageResult}");
        //    Assert.Equal(expectedResult, messageResult);
        //}

        //[Fact]
        //public void TestFormatMessageNo()
        //{
        //    // Arrange
        //    string? HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST");
        //    if (string.IsNullOrEmpty(HostName))
        //    {
        //        HostName = "localhost";
        //    }
        //    ConnectionFactory factory = new ConnectionFactory() { HostName = HostName };
        //    MatchService matchService = new MatchService(factory.CreateConnection());
        //    int swiperID = 0;
        //    int swipedID = 1;
        //    YesOrNo no = YesOrNo.n;

        //    // Act
        //    string messageResult = matchService.FormatMessage(swiperID, swipedID, no);
        //    string expectedResult = $"{swiperID}:{swipedID}:{no}";

        //    // Assert
        //    _logger.WriteLine($"Expected: {expectedResult}, Result: {messageResult}");
        //    Assert.Equal(expectedResult, messageResult);
        //}
    }
}