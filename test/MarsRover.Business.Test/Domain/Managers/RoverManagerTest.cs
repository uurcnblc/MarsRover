using MarsRover.Business.Domain.Enums;
using MarsRover.Business.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Test.Domain.Managers
{
    public class RoverManagerTest
    {
        [InlineData("1 3 E", 1, 3, RoverDirection.E)]
        [InlineData("2 1 W", 2, 1, RoverDirection.W)]
        public void SetRoverPositionGoodTest(string positionInput, int expectedX, int expectedY, RoverDirection expectedDirection)
        {
            #region Act
            RoverManager roverManager = new RoverManager();
            roverManager.SetRoverPosition(positionInput);
            #endregion

            #region Assert
            Assert.Equal(expectedX, roverManager.ActiveRover.CurrentPositionX);
            Assert.Equal(expectedY, roverManager.ActiveRover.CurrentPositionY);
            Assert.Equal(expectedDirection, roverManager.ActiveRover.CurrentDirection);
            #endregion
        }

        [InlineData("1 3 E", Movement.L, "1 3 N")]
        [InlineData("2 3 S", Movement.R, "1 3 W")]
        [InlineData("2 3 S", Movement.M, "2 2 S")]
        public void ApplyMovementGoodTest(string positionInput, Movement directionCommand, string expectedResult)
        {
            #region Act
            RoverManager roverManager = new RoverManager();
            roverManager.SetRoverPosition(positionInput);
            roverManager.ApplyMovement(directionCommand);
            string result = roverManager.GetActiveRoversCurrentPositionAsString();
            #endregion

            #region Assert
            Assert.Equal(expectedResult, result);
            #endregion
        }

        [InlineData("13 E")]
        [InlineData("K K 1")]
        public void SetRoverPositionBadTest(string positionInput)
        {
            bool exceptionIsThrowed = false;
            try
            {
                #region Act
                RoverManager roverManager = new RoverManager();
                roverManager.SetRoverPosition(positionInput);
                #endregion
            }
            catch (LogicException)
            {
                exceptionIsThrowed = true;
            }
            finally
            {
                #region Assert
                Assert.True(exceptionIsThrowed);
                #endregion
            }
        }

        [InlineData("1 3 E", null)]
        public void ApplyMovementBadTest(string positionInput, Movement directionCommand)
        {
            bool exceptionIsThrowed = false;
            try
            {
                #region Act
                RoverManager roverManager = new RoverManager();
                roverManager.SetRoverPosition(positionInput);
                roverManager.ApplyMovement(directionCommand);
                #endregion
            }
            catch (LogicException ex)
            {
                exceptionIsThrowed = true;
            }
            finally
            {
                #region Assert
                Assert.True(!exceptionIsThrowed);
                #endregion
            }
        }
    }
}
