using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat {
    [Serializable]
    public class CombatStatsContainer : Tools.TSVContainer
    {
        [SerializeField] public List<CombatStats> combatStats = new List<CombatStats>();

        public override void Parse(string rawText)
        {
            string[] lines = rawText.Split('\n');

            for (int i = 1; i < lines.Length; ++i)
            {
                string[] values = lines[i].Split('\t');
                string Name = values[0];
                List<int> stats = new List<int>();
                for (int j = 0; j < (int)StatType.COUNT; ++j)
                {
                    stats.Add(int.Parse(values[j + 1]));
                }

                CombatStats combatStats = new CombatStats(Name, stats);
                this.combatStats.Add(combatStats);
            }
            Debug.Assert(this.combatStats != null);
        }
    }
}
