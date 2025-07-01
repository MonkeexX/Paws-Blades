using UnityEngine;

namespace Combat
{
    public class Run : CombatChoice
    {
        const float runProbability = 0.7f;

        public static bool TryRun()
        {
            return Random.Range(0f, 1f) <= runProbability;
        }

        public override void Choose()
        {
            if(TryRun())
            {
                //Escape
            } else
            {
                //Escape failed
            }
        }
    }
}