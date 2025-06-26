using System;
using System.Collections.Generic;
using UnityEngine;

namespace SocialLink
{
    [Serializable]
    public class CharacterFile
    {
        public string Name; //Character name
        public SocialLevels socialLevel;
        public List<int> levelRequirements;

        public int XP;
        
        public void ModifyXP(int amount)
        {
            this.XP += amount;
            Debug.Log(Name + " " + XP);
            for (int i = 0; i < levelRequirements.Count; i++)
                if (levelRequirements[i] < XP) socialLevel = (SocialLevels)i;
        }

        public CharacterFile(string Name, SocialLevels socialLevel, int XP, List<int> levelRequirements)
        {
            this.Name = Name;
            this.socialLevel = socialLevel;
            //Debug.Assert(levelRequirements.Count == (int)SocialLink.SocialLevels.COUNT, "Level Requirements do not match!");
            this.levelRequirements = levelRequirements;
            this.XP = XP;
        }

        public CharacterFile(CharacterFile other)
        {
            this.Name = other.Name;
            this.socialLevel = other.socialLevel;
            this.levelRequirements = other.levelRequirements;
            this.XP = other.XP;
        }
    }
}
