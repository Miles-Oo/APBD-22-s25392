public class ContainerShip
{
    public string Name { get; private set; }
    private List<Container> Containers;
    public double MaxSpeed { get; private set; }
    public int MaxContainers { get; private set; }
    public double MaxWeight { get; private set; }
    

    public ContainerShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        Containers = new List<Container>();
    }

    public bool LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers || GetTotalWeight() + container.CurrentLoad > MaxWeight)
        {
            Console.WriteLine($"Unable to add container {container.SerialNumber} limit exceeded");
            return false;
        }

        Containers.Add(container);
        Console.WriteLine($"Added container {container.SerialNumber} to the {Name} ship");
        return true;
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = Containers.Find(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            Console.WriteLine($"Removed container {serialNumber} from {Name} ship");
        }
        else
        {
            Console.WriteLine($"The container {serialNumber} on the {Name} ship was not found");
        }
    }

    public bool ReplaceContainer(string serialNumber, Container newContainer)
    {
        for (int i = 0; i < Containers.Count; i++)
        {
            if (Containers[i].SerialNumber == serialNumber)
            {
                if (GetTotalWeight() - Containers[i].CurrentLoad + newContainer.CurrentLoad > MaxWeight)
                {
                    Console.WriteLine($"cannot replace container {serialNumber}, the new one exceeds the maximum weight.");
                    return false;
                }

                Containers[i] = newContainer;
                Console.WriteLine($"container {serialNumber} has been replaced by {newContainer.SerialNumber}.");
                return true;
            }
        }

        Console.WriteLine($"container {serialNumber} not found for replacement.");
        return false;
    }

    public bool TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        var container = Containers.Find(c => c.SerialNumber == serialNumber);
        if (container != null && targetShip.LoadContainer(container))
        {
            Containers.Remove(container);
            Console.WriteLine($"transferred container {serialNumber} to ship {targetShip.Name}.");
            return true;
        }
        Console.WriteLine($"failed to transfer container {serialNumber}.");
        return false;
    }

    public double GetTotalWeight()
    {
        double totalWeight = 0;
        foreach (var container in Containers)
        {
            totalWeight += container.CurrentLoad;
        }
        return totalWeight;
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship: {Name}, Speed: {MaxSpeed} knots, Containers: {Containers.Count}/{MaxContainers}, Weight: {GetTotalWeight()}/{MaxWeight} tons");
    }

    public void PrintContainerInfo(string serialNumber)
    {
        var container = Containers.Find(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Console.WriteLine($"container {container.SerialNumber}: Load: {container.CurrentLoad}/{container.MaxLoad} kg");
        }
        else
        {
            Console.WriteLine($"container {serialNumber} not found on ship {Name}.");
        }
    }
}