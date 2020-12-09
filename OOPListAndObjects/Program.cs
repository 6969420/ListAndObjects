using System;
using System.Collections.Generic;
using System.IO;

namespace OOPListAndObjects
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

        class ListOfPlanets
        {
            List<Planet> planets;
            int totalMass;

            public ListOfPlanets()
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
                foreach(Planet planetFromList in planets)
                {
                    Console.WriteLine($"Planet: {planetFromList.Name}; Mass: {planetFromList.Mass}");
                }
            }
        }

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"planet.txt";
            string fullPath = Path.Combine(filePath, fileName);
            ListOfPlanets newPlanetsList = new ListOfPlanets();
            string[] planetsFromFile = File.ReadAllLines(fullPath);

            foreach (string line in planetsFromFile)
            {
                string[] teampArray = line.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                string planetName = teampArray[0];
                int planetMass = int.Parse(teampArray[1]);
                Console.WriteLine(planetName);
                Console.WriteLine(planetMass);
                Console.WriteLine("----");

                newPlanetsList.AddPlanetToList(planetName, planetMass);

            }
            newPlanetsList.PrintPlanets();
        }
        
    }
}
