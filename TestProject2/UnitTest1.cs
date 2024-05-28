namespace TestProject2
{
    public class UnitTest1
    {
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