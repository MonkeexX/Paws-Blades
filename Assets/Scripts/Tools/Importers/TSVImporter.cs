using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;
using SocialLink;
using Dialog;

namespace Tools
{
    [ScriptedImporter(1, "tsv")]
    public class TSVImporter : ScriptedImporter
    {
        public enum ImportOption { DIALOG, CHARFILES }
        public ImportOption option = ImportOption.DIALOG;

        public override void OnImportAsset(AssetImportContext ctx)
        {
            Debug.Assert(ctx != null);
            string text = File.ReadAllText(ctx.assetPath);
            if (option == ImportOption.DIALOG)
            {
                DialogContainer container = DialogImport.ImportDialog(text);
                ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), container);
                ctx.SetMainObject(container);
            }
            else if (option == ImportOption.CHARFILES)
            {
                CharacterFileContainer container = CharacterFilesImport.ImportCharFiles(text);
                ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), container);
                ctx.SetMainObject(container);
            }
        }
    }
}