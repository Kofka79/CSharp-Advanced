using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Cars = new List<Car>();
            Type = type;
            Capacity = capacity;
        }

        public List<Car> Cars { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get { return Cars.Count; }
        }

        public void Add(Car car)
        {
            if (Cars.Count<Capacity)
            {
                Cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car currCar = Cars.FirstOrDefault(c => c.Manufacturer == manufacturer
                  && c.Model == model);
            if (Cars.Contains(currCar))
            {
                Cars.Remove(currCar);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Car GetLatestCar()
        {
            return Cars.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return Cars.FirstOrDefault(c => c.Manufacturer == manufacturer &&
                    c.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in Cars)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
