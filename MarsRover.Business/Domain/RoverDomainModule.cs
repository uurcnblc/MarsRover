namespace MarsRover.Business.Domain
{
    public class RoverDomainModule
    {
        internal RoverManager RoverManager { get; private set; }
        internal PlateauManager PlateauManager { get; private set; }

        public RoverDomainModule()
        {
            RoverManager = new RoverManager();
            PlateauManager = new PlateauManager();
        }

        public void SetPlateauSize(string plateuSize)
        {
            PlateauManager.SetPlateauSize(plateuSize);
        }

        public void SetRoverPosition(string position)
        {
            RoverManager.SetRoverPosition(position);
        }

        public string ApplyRoute(string route)
        {
            int tempX;
            int tempY;
            RoverDirection tempDirection;
            foreach (var item in route)
            {
                tempX = RoverManager.ActiveRover.CurrentPositionX;
                tempY = RoverManager.ActiveRover.CurrentPositionY;
                tempDirection = RoverManager.ActiveRover.CurrentDirection;
                Movement movement;
                if(Enum.TryParse(item.ToString(),true,out movement))
                {
                    RoverManager.ApplyMovement(movement);
                }
            }
            return RoverManager.GetActiveRoversCurrentPositionAsString();
        }
    }


}
