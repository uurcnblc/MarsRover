RoverDomainModule roverDomainModule = new RoverDomainModule();
Console.WriteLine("Please enter plateau size :");
var plateauSize = Console.ReadLine();
roverDomainModule.SetPlateauSize(plateauSize);

do
{
    Console.WriteLine("Please enter rover position :");
    string roverPositionInput = Console.ReadLine();
    roverDomainModule.SetRoverPosition(roverPositionInput);

    Console.WriteLine("Please enter rover command :");
    var roverCommandInput = Console.ReadLine();

    var lastPositionOfRover = roverDomainModule.ApplyRoute(roverCommandInput);
    Console.WriteLine("Expected Output : ");
    Console.WriteLine(lastPositionOfRover);

    Console.WriteLine("\n\rDo you want to repeat? (Y/N)");
    var repeatInput = Console.ReadLine();
    if (!repeatInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
        break;
}
while (true);

Console.WriteLine("\n\r");
Console.WriteLine("Press <enter> to exit...");
Console.ReadLine();