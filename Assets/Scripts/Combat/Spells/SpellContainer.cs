using System;
using System.Collections.Generic;
using System.IO;
using Tools;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace Combat
{
    public class SpellContainer : TSVContainer
    {
        public List<Spell> spells = new List<Spell>();
        public override void Import(string rawText, AssetImportContext ctx)
        {
            string[] lines = rawText.Split('\n');

            for (int i = 1; i < lines.Length; ++i)
            {
                string[] values = lines[i].Split('\t');
                string Name = values[0];
                string element = values[1];
                Debug.Assert(Enum.TryParse(values[2], out Spell.Categories category));
                Debug.Assert(int.TryParse(values[3], out int power));
                Debug.Assert(int.TryParse(values[4], out int accuracy));
                Debug.Assert(int.TryParse(values[5], out int pp));

                Spell spell = ScriptableObject.CreateInstance("Spell") as Spell;
                spell.SpellName = Name;
                spell.Element = element;
                spell.Category = category;
                spell.Power = power;
                spell.Accuracy = accuracy;
                spell.PP = pp;
                Debug.Assert(spell != null, "AAAA");
                spell.name = Name;
                this.spells.Add(spell);
                ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), spell);
            }
            Debug.Assert(this.spells != null);
            ctx.SetMainObject(spells[0]);
        }
    }
}