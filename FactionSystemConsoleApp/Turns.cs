using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactionSystemConsoleApp
{
    public class Turns
    {
        public void FactionTurnCycle(params FactionBase[] factionBases)
        {
            factionBases = factionBases.OrderBy(x=> RNG.Rand(0, factionBases.Length)).ToArray();
            foreach (var faction in factionBases)
            {
                PassGoFacCreds(faction);
                // temp
                faction.ContinueWithGoal(true);

                ///swich for the differnt action tybes factiobns can take
                ///loop till all oppertunities been used or till satified 

                if (faction.Goals.GoalCount <= faction.Goals.GoalCurrentCount)
                {
                    GoalSucces(faction);
                }
            }
        }

        public void PassGoFacCreds(FactionBase faction)
        {
            faction.FacCreds += faction.WealthRating / 2 + faction.ForceRating / 4 + faction.CunningRating / 4 - faction.CalcMaintenance();
            if (faction.FacCreds > 0)
            {
                /// do a thing that makes assets unavailable
            }
        }
        public void GoalSucces(FactionBase faction)
        {
            faction.ExperiencePoints += faction.Goals.CalcDifficulty();
        }
    }
}
