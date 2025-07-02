using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "TurnManager", menuName = "Scriptable Objects/Combat/TurnManager")]
    public class TurnManager : ScriptableObject
    {
        public bool isInCombat = false;
        public int activeActor = 0;
        [SerializeReference] public List<CombatActor> actorsInCombat = new List<CombatActor>();

        public void EnterCombat()
        {
            foreach (CombatActor actor in actorsInCombat) actor.StartCombat();
            activeActor = 0;
            isInCombat = true;
            actorsInCombat[activeActor].PromptChoice();
        }

        public void AddCombatActor(CombatActor actor)
        {
            actorsInCombat.Add(actor);
        }

        public void MakeTurn(CombatChoice choice)
        {
            if (!isInCombat) return;

            choice.Choose();

            activeActor++;
            activeActor %= actorsInCombat.Count;

            actorsInCombat[activeActor].PromptChoice();
        }

        public void ExitCombat()
        {
            foreach (CombatActor actor in actorsInCombat) actor.FinishCombat();
            actorsInCombat.Clear();
            isInCombat = false;
        }

    }
}