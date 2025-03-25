namespace Zadanie_1;


public class GasContainer : Containers, IHazardNotifier
{
    public double Pressure { get; } 

    public GasContainer(double mass, double height, double simpleWeight, double deepness, string number, double maxWeight, double pressure)
        : base(mass, height, simpleWeight, deepness, number, maxWeight)
    {
        Pressure = pressure;
    }

    public new void Reload(double addedMass)
    {
        if (Mass + addedMass > MaxWeight)
        {
            NotifyHazard($"[GAS HAZARD] Overfill in gas container {Number}.");
            throw new OverfillException("Gas container overfilled!");
        }

        Mass += addedMass;
    }

    public new void Unloading(int unloadedMass)
    {
        double FMass = Mass - unloadedMass;
        
        double remainingMass = Mass * 0.05;
        Mass = Math.Max(FMass, remainingMass);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD NOTIFICATION] {message} [Pressure: {Pressure} atm]");
    }
}