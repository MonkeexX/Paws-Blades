using UnityEngine;

namespace Combat
{
    public class Run
    {
        const float runProbability = 0.7f;

        public static bool TryRun()
        {
            return Random.Range(0f, 1f) <= runProbability;
        }
    }
}