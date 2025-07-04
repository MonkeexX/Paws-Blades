using UnityEngine;

namespace Combat
{
    public abstract class CombatChoice : ScriptableObject
    {
        public abstract void Choose();
    }
}