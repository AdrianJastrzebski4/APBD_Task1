namespace Zadanie_1;

public class RefrigeratedContainer : Containers
{
    public string ProductType { get; }
    public double Temperature { get; }
    
    private static readonly Dictionary<string, double> Temperatures = new()
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

    public RefrigeratedContainer(
        double mass,
        double height,
        double simpleWeight,
        double deepness,
        string number,
        double maxWeight,
        string productType,
        double temperature
    ) : base(mass, height, simpleWeight, deepness, number, maxWeight)
    {
        ProductType = productType;
        Temperature = temperature;

        if (Temperatures.ContainsKey(productType))
        {
            double required = Temperatures[productType];
            if (temperature < required)
            {
                throw new ArgumentException($"Container temperature too low for {productType}. Required: {required} °C, provided: {temperature} °C.");
            }
        }
    }

    public bool CanStore(string product)
    {
        return product.Equals(ProductType, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nProduct type: {ProductType}\n" +
               $"Temperature: {Temperature} °C";
    }
}