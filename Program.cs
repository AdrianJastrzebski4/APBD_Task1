using Zadanie_1;

using System;
using Zadanie_1;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Przykładowe konketnery: ");

            var container = new Containers(10, 220, 100, 200, "KON-C-1", 100);
            var liquidSafe = new LiquidContainers(0, 220, 120, 200, "KON-L-2", 100, false);
            var liquidHazard = new LiquidContainers(0, 220, 120, 200, "KON-L-3", 100, true);
            var gas = new GasContainer(50, 220, 100, 200, "KON-G-4", 100, 4.5);
            var fridge = new RefrigeratedContainer(30, 250, 90, 210, "KON-C-5", 80, "Fish", 5);
            

            Console.WriteLine("Test temperatury");
            try
            {
                var badFridge = new RefrigeratedContainer(30, 250, 90, 210, "KON-C-6", 80, "Fish", 0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("[EXCEPTION] " + ex.Message);
            }

            Console.WriteLine("Test ładowności");
            liquidSafe.Reload(80); 
            try { liquidHazard.Reload(60); } catch (Exception ex) { Console.WriteLine("[EXCEPTION] " + ex.Message); }

            gas.Reload(30); 
            gas.Unloading(100); 

            Console.WriteLine("Nowy statek");
            var ship1 = new ContainerShip("Dzik", 22, 2, 5); 
            ship1.AddContainer(container);
            ship1.AddContainer(liquidSafe);

            Console.WriteLine("Test ilościowy");
            try
            {
                ship1.AddContainer(gas);
                ship1.AddContainer(fridge); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION] " + ex.Message);
            }

            Console.WriteLine("Stan ");
            ship1.PrintShipInfo();

            Console.WriteLine("Usuwanie i zamiana ");
            ship1.RemoveContainer("KON-C-1");
            ship1.ReplaceContainer("KON-L-2", fridge);

            Console.WriteLine("Test tworzenia drugiego statku ");
            var ship2 = new ContainerShip("Koza", 52, 3, 11);
            ship1.TransferContainerTo("KON-C-5", ship2);

            Console.WriteLine("informajcje");
            Console.WriteLine("Ship 1");
            ship1.PrintShipInfo();

            Console.WriteLine("Ship 2");
            ship2.PrintShipInfo();

            Console.WriteLine("Wiadomości o kontenerze");
            ship2.PrintContainerInfo("KON-C-5");

            Console.WriteLine("Wron number test");
            try
            {
                var bad = new Containers(0, 220, 100, 200, "ABC-W-1", 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION] " + ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[UNEXPECTED ERROR] " + ex.Message);
        }
    }
}

