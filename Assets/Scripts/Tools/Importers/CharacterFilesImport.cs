using System.Collections.Generic;
using System;
using UnityEngine;

namespace SocialLink
{
    public static class CharacterFilesImport
    {
        public static CharacterFileContainer ImportCharFiles(string rawText)
        {
            CharacterFileContainer container = ScriptableObject.CreateInstance<CharacterFileContainer>();

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
                container.CharacterFiles.Add(file);
            }
            Debug.Assert(container != null);

            return container;
        }
    }
}