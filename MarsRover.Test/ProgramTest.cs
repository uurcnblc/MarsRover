namespace MarsRover.Test
{

    public class ProgramTest
    {
        public static IEnumerable<object[]> SampleDatas => new List<object[]> {
                new object[]{ "5 5", "1 2 N", "LMLMLMLMM","1 3 N"},
                new object[]{ "5 5", "3 3 E", "MMRMMRMRRM","5 1 E"}
            };


        [Theory]
        [MemberData(nameof(SampleDatas))]
        public void CreatePleateAndApplyCommand(string plateauSize,string roverPosition, string route, string expectedResult)
        {
            #region Act
            RoverDomainModule roverDomainModule = new RoverDomainModule();
            roverDomainModule.SetPlateauSize(plateauSize);
            roverDomainModule.SetRoverPosition(roverPosition);
            var actualResult = roverDomainModule.ApplyRoute(route);
            #endregion

            #region Assert
            Assert.Equal(expectedResult, actualResult);
            #endregion
        }
    }
}