using MarsRover.Business.Domain.Managers;

namespace MarsRover.Business.Test.Domain.Managers
{
    public class PlateauManagerTest
    {
        [Theory]
        [InlineData("5 5",5,5)]
        [InlineData("9 9",9,9)]
        public void TestSetPlateauGoodCase(string sizeInput, int expectedWidth, int expectedHeight)
        {
            PlateauManager plateauManager = new PlateauManager();
            plateauManager.SetPlateauSize(sizeInput);
            Assert.Equal(expectedWidth, plateauManager.ActivePlateau.Width);
            Assert.Equal(expectedHeight, plateauManager.ActivePlateau.Height);
        }

        [Theory]
        [InlineData("55")]
        [InlineData("9 9 9")]
        [InlineData("A C")]
        public void TestSetPlateauBadCase(string sizeInput)
        {
            bool exceptionThrowed = false; 
            try
            {
                PlateauManager plateauManager = new PlateauManager();
                plateauManager.SetPlateauSize(sizeInput);
            }
            catch (LogicException)
            {
                exceptionThrowed = true;
            }
            finally
            {
                Assert.True(exceptionThrowed);
            }
        }
    }
}
