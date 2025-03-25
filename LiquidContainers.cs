using System.ComponentModel;

namespace Zadanie_1;

public class LiquidContainers : Containers, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainers(double mass, double height, double simpleWeight, double deepness, string number, double maxWeight, bool isHazardous)
        : base(mass, height, simpleWeight, deepness, number, maxWeight)
    {
        IsHazardous = isHazardous;
    }

    public new void Reload(double addedMass)
    {
        double allowedLoad = IsHazardous ? MaxWeight * 0.5 : MaxWeight * 0.9;

        if (Mass + addedMass > allowedLoad)
        {
            NotifyHazard($"Liquid container {Number} is too big: ({allowedLoad} kg)");
            throw new OverfillException($"Can't add {addedMass} kg. Limit is {allowedLoad} kg.");
        }

        Mass += addedMass;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"HAZARD BE CAREFULL {message}");
    }
}