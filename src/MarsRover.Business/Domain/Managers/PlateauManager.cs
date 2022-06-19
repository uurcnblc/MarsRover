using MarsRover.Business.Domain.HelperTypes;

namespace MarsRover.Business.Domain.Managers
{
    public class PlateauManager
    {
        public Plateau ActivePlateau { get; private set; }
        public PlateauManager()
        {
            ActivePlateau = new Plateau();
        }

        public void SetPlateauSize(string plateauSize)
        {
            PlateauSize sizeObj = GetSizeFromString(plateauSize);
            ActivePlateau.Width = sizeObj.Width;
            ActivePlateau.Height = sizeObj.Height;
        }

        public PlateauSize GetSizeFromString(string plateauSize)
        {
            if (string.IsNullOrEmpty(plateauSize))
            {
                throw new LogicException("Plateau size parameters can not be empty!");
            }
            string[] plateuSizeArray = plateauSize.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int x;
            int y;
            if (plateuSizeArray?.Length == 2 && int.TryParse(plateuSizeArray[0],out x) && int.TryParse(plateuSizeArray[1],out y))
            {
                return new PlateauSize(x, y);
            }
            else
            {
                throw new LogicException("Plateau parameters must consist 2 integers.");
            }
        }
    }
}
