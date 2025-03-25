public class Container
{
    private static int counter = 0;
    public double CurrentLoad { get; private set; }
    public double Height { get; private set; }
    public double Weight { get; private set; }
    public double Depth { get; private set; }
    public string SerialNumber { get; private set; }
    public string ContainerType { get; private set; }
    public double MaxLoad { get; private set; }

    public Container(double maxLoad, double weight, double height, double depth, string containerType)
    {
        MaxLoad = maxLoad;
        Weight = weight;
        Height = height;
        Depth = depth;
        ContainerType = containerType;
        counter++;
        SerialNumber = $"KON-{ContainerType}-{counter}";
    }

    public virtual void Load(double weight)
    {
        if (CurrentLoad + weight <= MaxLoad)
        {
            CurrentLoad += weight;
            Console.WriteLine("Loaded " + weight + " kg. Current load: " + CurrentLoad + " kg");
        }
        else
        {
            throw new OverfillException("Max load exceeded ");
        }
    }

    public void SetLoad(double cargoWeight)
    {
        CurrentLoad = cargoWeight;
    }

    public virtual void Unload()
    {
        Console.WriteLine("Unloaded " + CurrentLoad + " kg of the container");
        CurrentLoad = 0;
    }
}
