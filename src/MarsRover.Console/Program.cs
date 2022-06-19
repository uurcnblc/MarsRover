

do
{
    try
    {
        RoverDomainModule roverDomainModule = new RoverDomainModule();
        Console.WriteLine("Please enter plateau size :");
        var plateauSize = Console.ReadLine();
        roverDomainModule.SetPlateauSize(plateauSize);

        Console.WriteLine("Please enter rover position :");
        string roverPositionInput = Console.ReadLine();
        roverDomainModule.SetRoverPosition(roverPositionInput);

        Console.WriteLine("Please enter rover command :");
        var roverCommandInput = Console.ReadLine();

        var lastPositionOfRover = roverDomainModule.ApplyRoute(roverCommandInput);
        Console.WriteLine("Expected Output : ");
        Console.WriteLine(lastPositionOfRover);

        Console.WriteLine("\n\rDo you want to continue? (Y/N)");
        var continueInput = Console.ReadLine();
        if (!continueInput.ToUpper().Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            break;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
while (true);

Console.WriteLine("\n\r");
Console.WriteLine("Press <enter> to exit...");
Console.ReadLine();