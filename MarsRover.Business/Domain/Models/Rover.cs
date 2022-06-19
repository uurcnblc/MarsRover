namespace MarsRover.Business.Domain.Models
{
    public class Rover
    {
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public RoverDirection CurrentDirection { get; set; }

        public Rover(int currentPositionX=0, int currentPositionY=0, RoverDirection currentDirection=RoverDirection.N)
        {
            this.CurrentPositionX = currentPositionX;
            this.CurrentPositionY = currentPositionY;
            this.CurrentDirection = currentDirection;
        }
    }
}
