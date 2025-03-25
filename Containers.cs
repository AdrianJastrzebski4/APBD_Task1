namespace Zadanie_1;

public class Containers
{
    public double Mass;
    public double Height;
    public double SimpleWeight;
    public double Deepness;
    public string Number;
    public double MaxWeight;
    

    public Containers(double mass, double height, double simpleWeight, double deepness, string number, double maxWeight)
    {
        if (!Checker(number))
            throw new ArgumentException("Wrong format [KON-<type>-<unique number>]");

        Mass = mass;
        Height = height;
        SimpleWeight = simpleWeight;
        Deepness = deepness;
        Number = number;
        MaxWeight = maxWeight;
    }

    private bool Checker(string number)
    {
        return number.StartsWith("KON-") && number.Split('-').Length == 3;
    }
    
    public override string ToString()
    {
        return $"Container number: {this.Number}\n" +
               $"Mass: {this.Mass} kg\n" +
               $"Height: {this.Height} m\n" +
               $"Simple Weight: {this.SimpleWeight} kg\n" +
               $"Deepness: {this.Deepness} m\n" +
               $"Max Weight: {this.MaxWeight} kg";
    }

    public void Reload(double addedMass)
    {
        if (this.Mass + addedMass > this.MaxWeight)
        {
            throw new OverfillException($"Cannot add {addedMass} kg. Max weight {MaxWeight} kg.");
        }

        this.Mass += addedMass;
    }
    
    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message) { }
    }
    
    
    public void Unloading(int unloadedContainersMass)
    {
        if (this.Mass - unloadedContainersMass < 0)
            this.Mass = 0;
        else
        {
            this.Mass -= unloadedContainersMass;
        }

    }
}



