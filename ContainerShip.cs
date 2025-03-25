using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie_1
{
    public class ContainerShip
    {
        public string Name { get; }
        public double MaxSpeedKnots { get; }    
        public int MaxContainerCount { get; }
        public double MaxLoadTons { get; }        

        private List<Containers> _containers = new();

        public ContainerShip(string name, double maxSpeedKnots, int maxContainerCount, double maxLoadTons)
        {
            Name = name;
            MaxSpeedKnots = maxSpeedKnots;
            MaxContainerCount = maxContainerCount;
            MaxLoadTons = maxLoadTons;
        }

        public bool AddContainer(Containers container)
        {
            if (_containers.Count >= MaxContainerCount)
                throw new InvalidOperationException("Max container count exceeded");

            double totalWeight = _containers.Sum(c => c.Mass + c.SimpleWeight) + container.Mass + container.SimpleWeight;
            if (totalWeight > MaxLoadTons * 1000)
                throw new InvalidOperationException("Max load (tons) exceeded");

            if (_containers.Any(c => c.Number == container.Number))
                throw new ArgumentException("Container with this number already exists on the ship");

            _containers.Add(container);
            return true;
        }

        public void RemoveContainer(string containerNumber)
        {
            var toRemove = _containers.FirstOrDefault(c => c.Number == containerNumber);
            if (toRemove != null)
                _containers.Remove(toRemove);
            else
                throw new ArgumentException("Container not found");
        }

        public void ReplaceContainer(string oldNumber, Containers newContainer)
        {
            RemoveContainer(oldNumber);
            AddContainer(newContainer);
        }

        public bool TransferContainerTo(string containerNumber, ContainerShip targetShip)
        {
            var container = _containers.FirstOrDefault(c => c.Number == containerNumber);
            if (container == null)
                return false;

            targetShip.AddContainer(container);
            _containers.Remove(container);
            return true;
        }

        public void PrintShipInfo()
        {
            Console.WriteLine($"Ship: {Name}");
            Console.WriteLine($"Speed: {MaxSpeedKnots} knots");
            Console.WriteLine($"Max Containers: {MaxContainerCount}");
            Console.WriteLine($"Max Load: {MaxLoadTons} tons");
            Console.WriteLine("--- Containers on board ---");
            foreach (var c in _containers)
            {
                Console.WriteLine(c);
                Console.WriteLine();
            }
        }

        public void PrintContainerInfo(string containerNumber)
        {
            var container = _containers.FirstOrDefault(c => c.Number == containerNumber);
            if (container != null)
                Console.WriteLine(container);
            else
                Console.WriteLine("Container not found on this ship");
        }
    }
}
