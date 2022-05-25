using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactionSystemConsoleApp
{
    public class AssetsForce : FactionAsset
    {
        public AssetsForce(int asseHitPoints, string assetName, int assetCost, int assetMaintenance, string assetAttack, string assetCounterattack, string assetType, Planet assetLocation, int assetTechLevel, string assetRatingTag, bool assetStealthed, string assetDamage, bool assetPlanetaryPermission) : base(asseHitPoints, assetName, assetCost, assetMaintenance, assetAttack, assetCounterattack, assetType, assetLocation, assetTechLevel, assetRatingTag, assetStealthed, assetDamage, assetPlanetaryPermission)
        {

        }
        // This asset has no extra ability
        public void SecurityPersonnel() { }
        // This asset has no extra ability
        public void Hitmen() { }
        // This asset has no extra ability
        public void MilitiaUnit() { }
        public void HeavyDropAssets(FactionAsset asset, FactionBase faction, Planet planet)
        {
            if (asset.AssetType != "Starship")
            {
                int x = asset.AssetLocation.PlanetLocation[0] - planet.PlanetLocation[0];
                int y = asset.AssetLocation.PlanetLocation[1] - planet.PlanetLocation[1];
                if(faction.FacCreds > 0)
                {
                    faction.FacCreds--;
                    if (x > 0) { asset.AssetLocation.PlanetLocation[0]++; }
                    if (x < 0) { asset.AssetLocation.PlanetLocation[0]--; }
                    if (y > 0) { asset.AssetLocation.PlanetLocation[1]++; }
                    if (y < 0) { asset.AssetLocation.PlanetLocation[1]--; }
                }
            }
        }
        // This asset has no extra ability
        public void EliteSkirmishers() { }
        // This asset has no extra ability
        public void HardenedPersonnel() { }
        // This asset has no extra ability
        public void GuerillaPopulace() { }
        // does damage to itself if succed in attack or counterattack 
        public void Zealots()
        {
            this.AssetHitPoints -= RNG.Dice(4);
        }
        // This asset has no extra ability
        public void CunningTrap() { }
        // This asset has no extra ability
        public void CounterintelUnit() { }
        public void BeachheadLanders(List<FactionAsset> assets, FactionBase faction, Planet planet)
        {
            if (assets.Any(x=> x.AssetLocation != planet))
            {
                foreach(var asset in assets)
                {
                    assets.Remove(asset);
                }
                int x = assets[0].AssetLocation.PlanetLocation[0] - planet.PlanetLocation[0];
                int y = assets[0].AssetLocation.PlanetLocation[1] - planet.PlanetLocation[1];
                if (faction.FacCreds > 0 + assets.Count())
                {
                    foreach (var item in assets)
                    {
                        faction.FacCreds--;
                        if (x > 0) { item.AssetLocation.PlanetLocation[0]++; }
                        if (x < 0) { item.AssetLocation.PlanetLocation[0]--; }
                        if (y > 0) { item.AssetLocation.PlanetLocation[1]++; }
                        if (y < 0) { item.AssetLocation.PlanetLocation[1]--; }
                    }
                }
            }
            else
            {
                int x = assets[0].AssetLocation.PlanetLocation[0] - planet.PlanetLocation[0];
                int y = assets[0].AssetLocation.PlanetLocation[1] - planet.PlanetLocation[1];
                if (faction.FacCreds > 0 + assets.Count())
                {
                    foreach (var item in assets)
                    {
                        faction.FacCreds--;
                        if (x > 0) { item.AssetLocation.PlanetLocation[0]++; }
                        if (x < 0) { item.AssetLocation.PlanetLocation[0]--; }
                        if (y > 0) { item.AssetLocation.PlanetLocation[1]++; }
                        if (y < 0) { item.AssetLocation.PlanetLocation[1]--; }
                    }
                }
            }
        }
        public void ExtendedTheater()
        {

        }
        public void StrikeFleet()
        {

        }
        public void PostechInfantry()
        {

        }
        public void BlockadeFleet()
        {

        }
        public void PretechLogistics()
        {

        }
        public void PsychicAssassins()
        {

        }
        public void PretechInfantry()
        {

        }
        public void PlanetaryDefenses()
        {

        }
        public void GravtankFormation()
        {

        }
        public void DeepStrikeLanders()
        {

        }
        public void IntegralProtocols()
        {

        }
        public void SpaceMarines()
        {

        }
        public void CapitalFleet()
        {

        }
    }
}
