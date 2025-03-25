public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; }

    public GasContainer(double maxLoad, double weight, double height, double depth, double pressure)
        : base(maxLoad, weight, height, depth, "G")
    {
        Pressure = pressure;
    }

    public override void Load(double weight)
    {
        if (CurrentLoad + weight > MaxLoad)
        {
            NotifyHazard($"Dangerous situation of the container numbered {SerialNumber}!");
            throw new OverfillException($"max load exceeded {SerialNumber}!");
        }

        base.Load(weight);
    }

    public override void Unload()
    {
        double remainingLoad = CurrentLoad * 0.05;
        Console.WriteLine($"5% of the gases from the previous load remain in container: {SerialNumber}: {remainingLoad} kg.");
        SetLoad(remainingLoad);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Danger {message}");
    }
}