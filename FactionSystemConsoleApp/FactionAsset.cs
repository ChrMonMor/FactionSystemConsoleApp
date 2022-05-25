using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactionSystemConsoleApp
{
    public class FactionAsset
    {
        private int _assetHitPoints;
        private string _assetName;
        private int _assetCost;
        private int _assetMaintenance;
        private string _assetAttack;
        private string _assetDamage;
        private string _assetCounterattack;
        private string _assetType;
        private Planet _assetLocation;
        private int _assetTechLevel;
        private string _assetRatingTag;
        private bool _assetStealthed;
        private bool _assetPlanetaryPermission;

        public int AssetHitPoints { get => _assetHitPoints; set => _assetHitPoints = value; }
        public string AssetName { get => _assetName; set => _assetName = value; }
        public int AssetCost { get => _assetCost; set => _assetCost = value; }
        public int AssetMaintenance { get => _assetMaintenance; set => _assetMaintenance = value; }
        public string AssetAttack { get => _assetAttack; set => _assetAttack = value; }
        public string AssetCounterattack { get => _assetCounterattack; set => _assetCounterattack = value; }
        public string AssetType { get => _assetType; set => _assetType = value; }
        public Planet AssetLocation { get => _assetLocation; set => _assetLocation = value; }
        public int AssetTechLevel { get => _assetTechLevel; set => _assetTechLevel = value; }
        public string AssetRatingTag { get => _assetRatingTag; set => _assetRatingTag = value; }
        public bool AssetStealthed { get => _assetStealthed; set => _assetStealthed = value; }
        public string AssetDamage { get => _assetDamage; set => _assetDamage = value; }
        public bool AssetPlanetaryPermission { get => _assetPlanetaryPermission; set => _assetPlanetaryPermission = value; }

        public FactionAsset(int asseHitPoints, string assetName, int assetCost, int assetMaintenance, string assetAttack, string assetCounterattack, string assetType, Planet assetLocation, int assetTechLevel, string assetRatingTag, bool assetStealthed, string assetDamage, bool assetPlanetaryPermission)
        {
            _assetHitPoints = asseHitPoints;
            _assetName = assetName;
            _assetCost = assetCost;
            _assetMaintenance = assetMaintenance;
            _assetAttack = assetAttack;
            _assetCounterattack = assetCounterattack;
            _assetType = assetType;
            _assetLocation = assetLocation;
            _assetTechLevel = assetTechLevel;
            _assetRatingTag = assetRatingTag;
            _assetStealthed = assetStealthed;
            _assetDamage = assetDamage;
            _assetPlanetaryPermission = assetPlanetaryPermission;
        }
        /// <summary>
        /// Using the a string that is the code for the dice. 
        /// </summary>
        /// <returns> the rolled dice(s) </returns>
        public int Attack()
        {
            int i = Convert.ToInt32(_assetAttack.First());
            int j = Convert.ToInt32(_assetAttack.Substring(1, 1));
            int k = 0;
            if (_assetAttack.Length == 3)
            {
                k = Convert.ToInt32(_assetAttack.Last());
            }
            if (j == 1)
            {
                j = 10;
            }
            for (int l = 0; l < i; l++)
            {
                k += RNG.Dice(j);
            }
            return k;
        }
        public int CounterAttack()
        {
            int i = Convert.ToInt32(_assetCounterattack.First());
            int j = Convert.ToInt32(_assetCounterattack.Substring(1, 1));
            int k = 0;
            if (_assetCounterattack.Length == 3)
            {
                k = Convert.ToInt32(_assetCounterattack.Last());
            }
            if (j == 1)
            {
                j = 10;
            }
            for (int l = 0; l < i; l++)
            {
                k += RNG.Dice(j);
            }
            return k;
        }
        /// <summary>
        /// Does the thing that asset have a ability to do.
        /// </summary>
        public void AssetAction()
        {

        }
    }
}
