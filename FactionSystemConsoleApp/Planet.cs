using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactionSystemConsoleApp
{
    public class Planet
    {
        private string _planetName;
        private string _planetDescription;
        private int[] _planetLocation;
        private long _planetPopulation;
        private int _planetTechLevel;

        public Planet(string name, string description, int[] location, long planetPopulation, int planetTechLevel)
        {
            _planetName = name;
            _planetDescription = description;
            _planetLocation = location;
            _planetPopulation = planetPopulation;
            _planetTechLevel = planetTechLevel;
        }

        public string PlanetName { get => _planetName; set => _planetName = value; }
        public string PlanetDescription { get => _planetDescription; set => _planetDescription = value; }
        public int[] PlanetLocation { get => _planetLocation; set => _planetLocation = value; }
        public long PlanetPopulation { get => _planetPopulation; set => _planetPopulation = value; }
        public int PlanetTechLevel { get => _planetTechLevel; set => _planetTechLevel = value; }
    }
}