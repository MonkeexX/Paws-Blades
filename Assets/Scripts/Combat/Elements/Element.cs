using System.Collections.Generic;
using System;

namespace Combat
{
    [Serializable]
    public struct Element
    {
        public string Name;
        public List<string> strengths;
        public List<string> weaknesses;

        public Element(string name)
        {
            this.Name = name;
            this.strengths = new List<string>();
            this.weaknesses = new List<string>();
        }
    }
}
