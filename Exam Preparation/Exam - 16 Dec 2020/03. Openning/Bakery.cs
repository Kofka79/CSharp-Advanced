using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if (data.Count<Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee currEmployee = data.FirstOrDefault(e => e.Name == name);
            if (data.Contains(currEmployee))
            {
                data.Remove(currEmployee);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(e => e.Name == name);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in data)
            {
                report.AppendLine(employee.ToString());
            }
            return report.ToString().TrimEnd();
        }
    }
}
