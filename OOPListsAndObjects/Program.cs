using System;
using System.Collections.Generic;
using System.IO;

namespace OOPListsAndObjects
{
    class Program
    {
        class Planet
        {
            string name;
            int mass;

            public Planet(string _name, int _mass)
            {
                name = _name;
                mass = _mass;
            }

            public string Name { get { return name; } }

            public int Mass { get { return mass; } }

        }
        class ListOffPlanets
        {
            List<Planet> planets;
            int totalMass;

            public ListOffPlanets()
            {
                planets = new List<Planet>();
                totalMass = 0;
            }

            public void AddPlanetToList(string planetName, int planetMass)
            {
                Planet newPlanet = new Planet(planetName, planetMass);
                planets.Add(newPlanet);
            }

            public void PrintPlanets()
            {
                foreach(Planet planetFromlist in planets)
                {
                    Console.WriteLine($"Planet: {planetFromlist.Name}; Mass: {planetFromlist.Mass}");
                }
            }
            
            public void FindandRemove(string searchEntry)
            {
                for(int i = 0; i < planets.Count; i++)
                {
                    if(planets[i].Name == searchEntry)
                    {
                        Console.WriteLine($"Planet {planets[i].Name} has been removed.");
                        planets.Remove(planets[i]);
                        break;
                    }
                }
            }
            public void CountPlanets()
            {
                Console.WriteLine($"There are {planets.Count} planets on the list.");
            }
        }
        static void Main(string[] args)
        {
            ListOffPlanets newPlanetsList = new ListOffPlanets();
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"Planets.txt";
            string fullPath = Path.Combine(filePath, fileName);

            string[] planetsFromFile = File.ReadAllLines(fullPath);

            foreach (string line in planetsFromFile)
            {
                string[] tempArray = line.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                string planetName = tempArray[0];
                int planetMass = int.Parse(tempArray[1]);
                Console.WriteLine(planetName);
                Console.WriteLine(planetMass);
                Console.WriteLine("----");

                newPlanetsList.AddPlanetToList(planetName, planetMass);
            }
            newPlanetsList.PrintPlanets();
            newPlanetsList.CountPlanets();

            Console.WriteLine("What planet do you want to remove");
            string userinput = Console.ReadLine();
            newPlanetsList.FindandRemove(userinput);

            newPlanetsList.PrintPlanets();
            newPlanetsList.CountPlanets();
        }
    }
}
 