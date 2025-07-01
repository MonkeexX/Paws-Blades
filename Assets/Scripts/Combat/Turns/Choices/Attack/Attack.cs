using UnityEngine;

namespace Combat
{
    public class Attack : CombatChoice
    {
        public void ChooseLimb()
        {

        }

        public bool Roll()
        {
            return Random.Range(1, 7) % 2 == 0; //Roll six sided die and get even/odd
        }

        public override void Choose()
        {
            throw new System.NotImplementedException();
        }
    }
}