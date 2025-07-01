using UnityEngine;

namespace Combat
{
    public class Magic : CombatChoice
    {
        public Spell spell;
        public CombatActor target;

        public Magic(Spell spell, CombatActor target)
        {
            this.spell = spell;
            this.target = target;
        }

        public override void Choose()
        {
            throw new System.NotImplementedException();
        }
    }
}