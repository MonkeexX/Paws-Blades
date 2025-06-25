using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

[UnityEditor.AssetImporters.ScriptedImporter(1, "tsv")]
public class TSVImporter : UnityEditor.AssetImporters.ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext ctx)
    {
        TextAsset textAsset = new TextAsset(File.ReadAllText(ctx.assetPath));
        ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), textAsset);
    }
}
