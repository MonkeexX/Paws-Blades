using System;
using System.Collections.Generic;
using UnityEngine;

namespace SocialLink
{
    [Serializable]
    public class CharacterFileContainer : Tools.TSVContainer
    {
        public List<CharacterFile> CharacterFiles = new List<CharacterFile>();

        public override void Parse(string rawText)
        {
            string[] lines = rawText.Split('\n');
            for (int i = 1; i < lines.Length; ++i)
            {
                string[] values = lines[i].Split('\t');
                string Name = values[0];
                Debug.Assert(Enum.TryParse(values[1], out SocialLevels socialLevel));
                Debug.Assert(int.TryParse(values[2], out int XP));
                List<int> levelRequirements = new List<int>();
                for (int j = 3; j < values.Length; j++)
                {
                    Debug.Assert(int.TryParse(values[j].TrimEnd('\r'), out int req));
                    levelRequirements.Add(req);
                }
                CharacterFile file = new CharacterFile(Name, socialLevel, XP, levelRequirements);
                this.CharacterFiles.Add(file);
            }
            Debug.Assert(this.CharacterFiles != null);
        }
    }
}
