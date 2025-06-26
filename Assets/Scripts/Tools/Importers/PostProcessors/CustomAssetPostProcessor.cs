using System.IO;
using UnityEditor;
using UnityEngine;

namespace Tools
{
    public class CustomAssetPostProcessor : AssetPostprocessor
    {
        private void OnPreprocessAsset()
        {
            if (assetPath.EndsWith(".tsv"))
            {
                if (EditorUtility.DisplayDialog("TSV Import Options",
                        "How would you like to import this TSV file?",
                        "Dialog", "CharFiles"))
                {
                    var importer = AssetImporter.GetAtPath(assetPath) as TSVImporter;
                    importer.option = TSVImporter.ImportOption.DIALOG;
                }
                else
                {
                    var importer = AssetImporter.GetAtPath(assetPath) as TSVImporter;
                    importer.option = TSVImporter.ImportOption.CHARFILES;
                }
            }
        }
    }
}