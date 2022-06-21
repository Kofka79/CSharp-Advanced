using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Pets = new List<Pet>();
            Capacity = capacity;
        }
        
        public List<Pet> Pets { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get{ return Pets.Count(); }
        }

        public void Add(Pet pet)
        {
            if (Pets.Count<Capacity)
            {
                Pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet currPet = Pets.FirstOrDefault(p => p.Name == name);
            if (Pets.Contains(currPet))
            {
                Pets.Remove(currPet);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Pet GetPet(string name, string owner)
        {
            Pet newPet = Pets.FirstOrDefault(p => p.Name == name &&
                          p.Owner == owner);
            return newPet;
        }

        public Pet GetOldestPet()
        {
            return Pets.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in Pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
