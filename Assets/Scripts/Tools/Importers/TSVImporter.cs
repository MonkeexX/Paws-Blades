using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;
using SocialLink;
using Dialog;
using Combat;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Tools
{
    [ScriptedImporter(1, "tsv")]
    public class TSVImporter : ScriptedImporter
    {
        public enum ImportOption { DIALOG, CHARFILES, COMBATSTATS, SPELLS }
        public ImportOption option = ImportOption.DIALOG;

        public readonly Dictionary<ImportOption, string> optionTypes = new Dictionary<ImportOption, string>{
            { ImportOption.DIALOG, typeof(DialogContainer).Name },
            { ImportOption.CHARFILES, typeof(CharacterFileContainer).Name },
            { ImportOption.COMBATSTATS, typeof(CombatStatsContainer).Name },
            { ImportOption.SPELLS, typeof(SpellContainer).Name }
        };

        public override void OnImportAsset(AssetImportContext ctx)
        {
            Debug.Assert(ctx != null);
            string text = File.ReadAllText(ctx.assetPath);

            TSVContainer container = ScriptableObject.CreateInstance(optionTypes[option]) as TSVContainer;
            container.Import(text, ctx);
        }
    }
}