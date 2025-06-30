using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace SocialLink
{
    [Serializable]
    public class CharacterFileContainer : Tools.TSVContainer
    {
        public List<CharacterFile> CharacterFiles = new List<CharacterFile>();

        public override void Import(string rawText, AssetImportContext ctx)
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
                file.name = Name;
                this.CharacterFiles.Add(file);
                ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), file);
            }
            Debug.Assert(this.CharacterFiles != null);
            ctx.SetMainObject(CharacterFiles[0]);
        }
    }
}
