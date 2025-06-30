using System.IO;
using UnityEditor;
using UnityEngine;

namespace Tools
{
    public class CustomAssetPostProcessor : AssetPostprocessor
    {
        private string[] options = { "Dialog", "CharFiles" };
        private void OnPreprocessAsset()
        {
            if (!assetPath.EndsWith(".tsv")) return;

            var importer = AssetImporter.GetAtPath(assetPath) as TSVImporter;

            if (assetPath.Contains("/Dialogs/"))
            {
                importer.option = TSVImporter.ImportOption.DIALOG;
                return;
            }

            if (assetPath.Contains("/Character Files/"))
            {
                importer.option = TSVImporter.ImportOption.CHARFILES;
                return;
            }

            if(assetPath.Contains("/Combat Stats/"))
            {
                importer.option = TSVImporter.ImportOption.COMBATSTATS;
                return;
            }

            if(assetPath.Contains("/Spells/"))
            {
                importer.option = TSVImporter.ImportOption.SPELLS;
                return;
            }

            bool option = false;
            int selectable = 0;
            do
            {
                selectable++;
                selectable %= 2;

                option = EditorUtility.DisplayDialog("TSV Import Options",
                    $"How would you like to import '{assetPath}'?",
                    $"'{options[selectable]}'",
                    "Continue");

            } while (!option);

            importer.option = (TSVImporter.ImportOption)selectable;
        }
    }
}