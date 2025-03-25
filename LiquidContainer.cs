public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(double maxLoad, double weight, double height, double depth, bool isHazardous)
        : base(maxLoad, weight, height, depth, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        double maxAllowedLoad = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;

        if (CurrentLoad + weight > maxAllowedLoad)
        {
            NotifyHazard($"Dangerous situation of the container numbered {SerialNumber}");
            return;
        }

        base.Load(weight);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Danger {message}");
    }
}