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
            #region Act
            PlateauManager plateauManager = new PlateauManager();
            plateauManager.SetPlateauSize(sizeInput);
            #endregion

            #region Assert
            Assert.Equal(expectedWidth, plateauManager.ActivePlateau.Width);
            Assert.Equal(expectedHeight, plateauManager.ActivePlateau.Height);
            #endregion
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
                #region Act
                PlateauManager plateauManager = new PlateauManager();
                plateauManager.SetPlateauSize(sizeInput);
                #endregion
            }
            catch (LogicException)
            {
                exceptionThrowed = true;
            }
            finally
            {
                #region Assert
                Assert.True(exceptionThrowed);
                #endregion
            }
        }
    }
}
