using MarsRover.Business.Domain.HelperTypes;

namespace MarsRover.Business.Domain.Managers
{
    public class RoverManager
    {
        public Rover ActiveRover { get; private set; }
        public RoverManager()
        {
            ActiveRover = new Rover();
        }

        #region Public Methods
        public void SetRoverPosition(string position)
        {
            var positionObj = GetPositionFromString(position);
            ActiveRover.CurrentPositionX = positionObj.X;
            ActiveRover.CurrentPositionY = positionObj.Y;
            ActiveRover.CurrentDirection = positionObj.Direction;
        }

        public void ApplyMovement(Movement movement)
        {
            switch (movement)
            {
                case Movement.L:
                    TurnLeft();
                    break;
                case Movement.R:
                    TurnRight();
                    break;
                case Movement.M:
                    Move();
                    break;
                default:
                    throw new LogicException(nameof(movement));
            }
        }

        public string GetActiveRoversCurrentPositionAsString()
        {
            return $"{ActiveRover.CurrentPositionX} {ActiveRover.CurrentPositionY} {ActiveRover.CurrentDirection}";
        }
        #endregion

        #region Private Methods
        private void TurnLeft()
        {
            ActiveRover.CurrentDirection = (ActiveRover.CurrentDirection - 1) < RoverDirection.N ? RoverDirection.W : ActiveRover.CurrentDirection - 1;
        }

        private void TurnRight()
        {
            ActiveRover.CurrentDirection = (ActiveRover.CurrentDirection + 1) > RoverDirection.W ? RoverDirection.N : ActiveRover.CurrentDirection + 1;
        }

        private void Move()
        {
            switch (ActiveRover.CurrentDirection)
            {
                case RoverDirection.N:
                    ActiveRover.CurrentPositionY++;
                    break;
                case RoverDirection.E:
                    ActiveRover.CurrentPositionX++;
                    break;
                case RoverDirection.S:
                    ActiveRover.CurrentPositionY--;
                    break;
                case RoverDirection.W:
                    ActiveRover.CurrentPositionX--;
                    break;
                default:
                    throw new ArgumentNullException();
            }
        }

        private Position GetPositionFromString(string position)
        {
            if (string.IsNullOrEmpty(position))
            {
                throw new LogicException("Position parameters can not be empty!");
            }
            string[] positionArray = position.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (positionArray?.Length != 3)
            {
                throw new LogicException("Rover parameters must consist 2 integers and 1 direction flag (N,E,S or W).");
            }
            string direction = positionArray[2].ToUpper();
            RoverDirection roverDirection;
            int x;
            int y;
            if (int.TryParse(positionArray[0], out x) && int.TryParse(positionArray[1], out y) && Enum.TryParse(direction, true, out roverDirection))
            {
                return new Position(x,y, roverDirection);
            }
            else
            {
                throw new LogicException("Direction flag is not valid. It can be only 'N','E','S' or 'W'.");
            }
        }
        #endregion
    }
}
