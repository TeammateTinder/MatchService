using MatchServiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RabbitMQ.Client;
using Xunit.Abstractions;

namespace MatchServiceAppTests
{
    public class MatchServiceTests
    {
        private readonly ITestOutputHelper _logger;

        public MatchServiceTests(ITestOutputHelper logger)
        {
            _logger = logger;

        }

        [Fact]
        public void TestFormatMessageYes()
        {

            // Arrange
            int swiperID = 0;
            int swipedID = 1;
            YesOrNo yes = YesOrNo.y;

            // Act
            string messageResult = MatchService.FormatMessage(swiperID, swipedID, yes);
            string expectedResult = $"{swiperID}:{swipedID}:{yes}";

            // Assert
            _logger.WriteLine($"Expected: {expectedResult}, Result: {messageResult}");
            Assert.Equal(expectedResult, messageResult);
        }

        [Fact]
        public void TestFormatMessageNo()
        {
            // Arrange
            int swiperID = 0;
            int swipedID = 1;
            YesOrNo no = YesOrNo.n;

            // Act
            string messageResult = MatchService.FormatMessage(swiperID, swipedID, no);
            string expectedResult = $"{swiperID}:{swipedID}:{no}";

            // Assert
            _logger.WriteLine($"Expected: {expectedResult}, Result: {messageResult}");
            Assert.Equal(expectedResult, messageResult);
        }
    }
}