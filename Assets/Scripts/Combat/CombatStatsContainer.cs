using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat {
    [Serializable]
    public class CombatStatsContainer : ScriptableObject
    {
        [SerializeField] public List<CombatStats> combatStats = new List<CombatStats>();
    }
}
