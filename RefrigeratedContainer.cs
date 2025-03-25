public class RefrigeratedContainer : Container
{
    public string ProductType { get; private set; }
    public double Temperature { get; private set; }

    private static Dictionary<string, double> ProductTemperatures = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public RefrigeratedContainer(double maxLoad, double weight, double height, double depth, string productType, double temperature)
        : base(maxLoad, weight, height, depth, "C")
    {
        if (!ProductTemperatures.ContainsKey(productType))
        {
            throw new ArgumentException("Unsupported product type");
        }

        if (temperature < ProductTemperatures[productType])
        {
            throw new ArgumentException($"The temperature of the container must not be lower than {ProductTemperatures[productType]}°C for the product {productType}");
        }

        ProductType = productType;
        Temperature = temperature;
    }

    public override void Load(double weight)
    {
        if (CurrentLoad > 0)
        {
            throw new InvalidOperationException($"{SerialNumber} container can only store one type of product ({ProductType})");
        }

        base.Load(weight);
    }
}
