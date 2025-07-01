using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public static class TurnManager
    {
        public static bool isInCombat = false;
        public static int activeActor = 0;
        public static List<CombatActor> actorsInCombat = new List<CombatActor>();

        public static void EnterCombat()
        {
            activeActor = 0;
            isInCombat = true;
        }

        public static void AddCombatActor(CombatActor actor)
        {
            actorsInCombat.Add(actor);
        }

        public static void MakeTurn(CombatActor actor, CombatChoice choice)
        {
            if (!isInCombat || actor != actorsInCombat[activeActor]) return;

            choice.Choose();

            activeActor++;
            activeActor %= actorsInCombat.Count;
        }

        public static void ExitCombat()
        {
            actorsInCombat.Clear();
            isInCombat = false;
        }

    }
}