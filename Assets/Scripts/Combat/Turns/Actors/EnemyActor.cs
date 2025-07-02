using UnityEngine;

namespace Combat
{
    public class EnemyActor : CombatActor
    {
        [SerializeField] private EnemyAI ai;

        public override void StartCombat() {}

        public override void PromptChoice() => ai.PromptChoice();

        public override void FinishCombat() {}
    }
}