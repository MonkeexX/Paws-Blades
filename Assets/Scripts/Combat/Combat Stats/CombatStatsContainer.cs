using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace Combat {
    [Serializable]
    public class CombatStatsContainer : Tools.TSVContainer
    {
        [SerializeField] public List<CombatStats> combatStats = new List<CombatStats>();

        public override void Import(string rawText, AssetImportContext ctx)
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
                combatStats.name = Name;
                this.combatStats.Add(combatStats);
                ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), combatStats);
            }
            Debug.Assert(this.combatStats != null);
            ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), this);
            ctx.SetMainObject(this);
        }
    }
}
