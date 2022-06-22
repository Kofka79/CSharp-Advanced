using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        
        public List<Fish> Fish { get; set; }

        public string Material { get; set; }

        public int Capacity { get; set; }

        public int Count => this.Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType)||fish.Length<=0 || fish.Weight<=0)
            {
                return "Invalid fish.";
            }
            if (Fish.Count==Capacity)
            {
                return "Fishing net is full.";
            }
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public  bool ReleaseFish(double weight)
        {
            Fish currfish = Fish.FirstOrDefault(f => f.Weight == weight);
            if (Fish.Contains(currfish))
            {
                Fish.Remove(currfish);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Fish GetFish(string fishType) 
        {
            Fish fishToReturn = Fish.FirstOrDefault(f => f.FishType == fishType);
            return fishToReturn;
        }

        public Fish GetBiggestFish()
        {
            Fish longestFish = Fish.OrderByDescending(f => f.Length).FirstOrDefault();
            return longestFish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in Fish.OrderByDescending(x=>x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
