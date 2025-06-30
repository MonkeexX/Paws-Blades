using UnityEngine;


namespace Combat {
    [CreateAssetMenu(fileName = "Spell", menuName = "Scriptable Objects/Combat/Spell")]
    public class Spell : ScriptableObject
    {
        public enum Categories { PHYSICAL, SPECIAL, STATUS }

        [SerializeField] private string spellName;
        public string SpellName { get { return spellName; } set { spellName = value; } }

        [SerializeField] private string element;
        public string Element { get { return element; } set { element = value; } }
        [SerializeField] private Categories category;
        public Categories Category { get { return category; } set { category = value; } }
        [SerializeField] private int power;
        public int Power { get { return power; } set { power = value; } }
        [SerializeField] private int accuracy;
        public int Accuracy { get { return accuracy; } set { accuracy = value; } }
        [SerializeField] private int pp;
        public int PP { get { return pp; } set { pp = value; } }

        public Spell(string spellName, string element, Categories category, int power, int accuracy, int pp) 
        {
            this.spellName = spellName;
            this.element = element;
            this.category = category;
            this.power = power;
            this.accuracy = accuracy;
            this.pp = pp;
        }
    }
}