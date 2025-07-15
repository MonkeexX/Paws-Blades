using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Combat
{
    public enum StatType { LUST, GLUTTONY, GREED, SLOTH, WRATH, ENVY, PRIDE, COUNT }

    [Serializable]
    public class CombatStats : ScriptableObject
    {
        [SerializeField] string Name;
        [SerializeField] List<int> stats;

        public int GetStat(StatType type) => this.stats[(int)type];
        public void SetStat(StatType type, int value) => stats[(int)type] = value;
        public void AddStat(StatType type, int value) => stats[(int)type] += value;
        public void RemoveStat(StatType type, int value) => stats[(int)type] -= value;
        public void ResetStat(StatType type) => stats[(int)type] = 0;
        public void ResetStats() => stats = new List<int>();

        public CombatStats(string name, List<int> stats)
        {
            this.Name = name;
            this.stats = new List<int>();
            foreach(int stat in stats) this.stats.Add(stat);
            //for(int i = 0; i < (int)StatType.COUNT; i++)
            //{
            //    this.stats[i] = stats[i];
            //}
        }
    }
}
