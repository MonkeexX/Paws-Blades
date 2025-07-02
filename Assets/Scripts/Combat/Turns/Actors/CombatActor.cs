using System;
using UnityEngine;

namespace Combat
{
    public abstract class CombatActor : ScriptableObject
    {
        [SerializeField] protected CombatStats stats;
        public CombatStats Stats { get { return stats; } }
        [SerializeField] protected Spell[] spells;
        public Spell[] Spells { get { return spells; } }

        public abstract void StartCombat();
        public abstract void PromptChoice();
        public abstract void FinishCombat();
    }
}