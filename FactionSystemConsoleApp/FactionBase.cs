using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactionSystemConsoleApp
{
    public class FactionBase
    {
        /// <summary>
        /// This is the overall Faction Base. All other types of factions will inherret
        ///   this basic struckter and logic
        /// </summary>
        readonly int[,] vs = new int[,] { { 0, 0 }, { 1, 1 }, { 2, 2 }, { 3, 4 }, { 4, 6 }, { 5, 9 }, { 6, 12 }, { 7, 16 }, { 8, 20 } };

        private int _wealthRating;
        private int _forceRating;
        private int _cunningRating;
        private int _hitPoints;
        private int _facCreds;
        private int _experiencePoints;
        private string _name;
        private string _description;
        private Planet _homeWorld;
        private string[] _tags;
        private List<FactionAsset> _assets;
        private FactionGoals _goals;

        public int WealthRating { get => _wealthRating; set => _wealthRating = value; }
        public int ForceRating { get => _forceRating; set => _forceRating = value; }
        public int CunningRating { get => _cunningRating; set => _cunningRating = value; }
        public int HitPoints { get => _hitPoints; set => _hitPoints = value; }
        public int FacCreds { get => _facCreds; set => _facCreds = value; }
        public int ExperiencePoints { get => _experiencePoints; set => _experiencePoints = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public Planet HomeWorld { get => _homeWorld; set => _homeWorld = value; }
        public string[] Tags { get => _tags; set => _tags = value; }
        public List<FactionAsset> Assets { get => _assets; set => _assets = value; }
        public FactionGoals Goals { get => _goals; set => _goals = value; }

        public FactionBase(int wealthRating, int forceRating, int cunningRating, int hitPoints, int facCreds, int experiencePoints, string name, string description, Planet homeWorld, string[] tags, FactionGoals goals)
        {
            _wealthRating = wealthRating;
            _forceRating = forceRating;
            _cunningRating = cunningRating;
            _hitPoints = hitPoints;
            _facCreds = facCreds;
            _experiencePoints = experiencePoints;
            _name = name;
            _description = description;
            _homeWorld = homeWorld;
            _tags = tags;
            _assets = new List<FactionAsset>() { new FactionAsset(MaxHitPoint(), "Base of Influence", 0, 0, null, null, "HQ", homeWorld, 0, "HQ", false, null, false) };
            _goals = goals;
        }
        public int CalcMaintenance()
        {
            int cost = 0;
            int w = _wealthRating;
            int f = _forceRating;
            int c = _cunningRating;
            foreach (var asset in _assets)
            {
                cost += asset.AssetMaintenance;
                if(asset.AssetRatingTag == "wealth") { w--; }
                else if (asset.AssetRatingTag == "force") { f--; }
                else { c--; }
            }
            if (w < 0) { cost -= w; }
            if (f < 0) { cost -= f; }
            if (c < 0) { cost -= c; }
            return cost;
        }

        ///Actions 
        public void Attack(FactionBase enemyBase, FactionAsset enemyAsset, List<FactionAsset> AllyAssets)
        {
            if (enemyAsset.AssetStealthed == false)
            {
                foreach (var asset in AllyAssets)
                {
                    if(asset.AssetLocation != enemyAsset.AssetLocation)
                    {
                        AllyAssets.Remove(asset);
                    }
                }
                AllyAssets.OrderBy(x => x.AssetCounterattack).ToList();
                foreach (var item in AllyAssets)
                {
                    int attackerRoll = RNG.Dice(10);
                    int defenderRoll = RNG.Dice(10);
                    switch (item.AssetAttack.First())
                    {
                        case 'C':
                            attackerRoll += CunningRating;
                            break;
                        case 'F':
                            attackerRoll += ForceRating;
                            break;
                        case 'W':
                            attackerRoll += WealthRating;
                            break;
                        default:
                            break;
                    }
                    switch (item.AssetAttack.Last())
                    {
                        case 'C':
                            defenderRoll += enemyBase.CunningRating;
                            break;
                        case 'F':
                            defenderRoll += enemyBase.ForceRating;
                            break;
                        case 'W':
                            defenderRoll += enemyBase.WealthRating;
                            break;
                        default:
                            break;
                    }
                    if (attackerRoll > defenderRoll)
                    {
                        enemyAsset.AssetHitPoints -= item.Attack();
                    }
                    else if (attackerRoll < defenderRoll)
                    {
                        item.AssetHitPoints -= enemyAsset.CounterAttack();
                    }
                    else
                    {
                        enemyAsset.AssetHitPoints -= item.Attack();
                        item.AssetHitPoints -= enemyAsset.CounterAttack();
                    }
                }
            }
        }
        public void BuyAsset(FactionAsset asset, Planet planet, bool permission)
        {
            int bribe = RNG.Dice(4);
            string spaceship = "Starship";
            int minimum = 900000;
            if (asset.AssetTechLevel >= planet.PlanetTechLevel)
            {
                if (permission == asset.AssetPlanetaryPermission || !asset.AssetPlanetaryPermission)
                {
                    if (asset.AssetType == spaceship)
                    {
                        if (planet.PlanetPopulation >= minimum)
                        {
                            Assets.Add(asset);
                            _facCreds -= asset.AssetCost;
                        }
                    }
                    else if (_facCreds >= 0 + asset.AssetCost)
                    {
                        Assets.Add(asset);
                        _facCreds -= asset.AssetCost;
                    }
                }
                else if (_facCreds >= 0 + asset.AssetCost + bribe)
                {
                    if (asset.AssetType == spaceship)
                    {
                        if (planet.PlanetPopulation >= minimum)
                        {
                            Assets.Add(asset);
                            _facCreds -= asset.AssetCost + bribe;
                        }
                    }
                    else if (_facCreds >= 0 + asset.AssetCost)
                    {
                        Assets.Add(asset);
                        _facCreds -= asset.AssetCost + bribe;
                    }
                }
            }
        }
        public void ChangeHomeworld(Planet targetPlanet)
        {
            if (Assets.Count(x => x.AssetType == "HQ") >= 2 && Assets.Any(x => x.AssetLocation == targetPlanet))
            {
                _homeWorld = Assets.Find(x => x.AssetLocation == targetPlanet && x.AssetType == "HQ").AssetLocation;
                int a = _homeWorld.PlanetLocation[0] - targetPlanet.PlanetLocation[0];
                int b = _homeWorld.PlanetLocation[1] - targetPlanet.PlanetLocation[1];
                b = Convert.ToInt32(Math.Sqrt(b * b + a * a));
            }

        }
        public void ExpandInfluence(Planet targetplanet, params FactionBase[] factions)
        {
            if (_assets.Any(x => x.AssetLocation == targetplanet))
            {
                int a = RNG.Dice(10) + _cunningRating;
                
                foreach (var item in factions)
                {
                    if (item._assets.Any(x=> x.AssetLocation == targetplanet))
                    {

                    }
                }
            }
        }
        public void RefitAsset()
        {

        }
        public void RepairAssetOrFaction(FactionAsset asset, int fatCred)
        {
            if (_assets.Contains(asset))
            {
                if (asset.AssetRatingTag == "Cunning")
                {
                    asset.AssetHitPoints += _cunningRating * fatCred;
                }
                else if (asset.AssetRatingTag == "Force")
                {
                    asset.AssetHitPoints += _forceRating * fatCred;
                }
                else if (asset.AssetRatingTag == "Wealth")
                {
                    asset.AssetHitPoints += _wealthRating * fatCred;
                }
                else
                {
                    if (_cunningRating >= _forceRating && _cunningRating >= _wealthRating)
                    {
                        asset.AssetHitPoints += _cunningRating * fatCred;
                    }
                    else if (_forceRating >= _cunningRating && _forceRating >= _wealthRating)
                    {
                        asset.AssetHitPoints += _forceRating * fatCred;
                    }
                    else
                    {
                        asset.AssetHitPoints += _wealthRating * fatCred;
                    }
                }
            }
        }
        public void SellAsset(FactionAsset asset)
        {
            if (_assets.Contains(asset))
            {
                _assets.Remove(asset);
                _facCreds += asset.AssetCost / 2;
            }
        }
        public void SeizePlanet()
        {

        }
        public void UseAssetAbility()
        {

        }
        public void ContinueWithGoal(bool answer)
        {

        }

        public int MaxHitPoint()
        {
            return 4 + vs[_cunningRating, 1] + vs[_forceRating, 1] + vs[_wealthRating, 1];
        }
        public void RaisingFactionAttributes(string attribute)
        {
            if (attribute == "Cunning")
            {
                if (_experiencePoints >= vs[_cunningRating + 1,1])
                {
                    _experiencePoints -= vs[_cunningRating + 1, 1];
                    _cunningRating += 1;
                }
            }
            else if (attribute == "Force")
            {
                if (_experiencePoints >= vs[_forceRating + 1, 1])
                {
                    _experiencePoints -= vs[_forceRating + 1, 1];
                    _forceRating += 1;
                }
            }
            else
            {
                if (_experiencePoints >= vs[_wealthRating + 1, 1])
                {
                    _experiencePoints -= vs[_wealthRating + 1, 1];
                    _wealthRating += 1;
                }
            }
        }
    }
}