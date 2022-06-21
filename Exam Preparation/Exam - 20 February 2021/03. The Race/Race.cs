using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    class Race
    {
        public Race(string name, int capacity)
        {
            Racers = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }

        public List<Racer> Racers { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => Racers.Count;

        public void Add(Racer racer)
        {
            if (Racers.Count<Capacity)
            {
                Racers.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            Racer currRacer = Racers.FirstOrDefault(r => r.Name == name);
            if (Racers.Contains(currRacer))
            {
                Racers.Remove(currRacer);
                return true;
            }
            else
            {
                return false;
            }
        }

        public  Racer GetOldestRacer()
        {
            return Racers.OrderByDescending(r => r.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return Racers.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return Racers.OrderByDescending(c => c.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in Racers)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
