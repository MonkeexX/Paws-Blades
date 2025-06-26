using System.Collections.Generic;
using System;
using System.IO;
using SocialLink;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;
using Dialog;
using UnityEngine.LightTransport;

[UnityEditor.AssetImporters.ScriptedImporter(1, "tsv")]
public class TSVImporter : UnityEditor.AssetImporters.ScriptedImporter
{
    public enum ImportOption { DIALOG, CHARFILES }
    public ImportOption option = ImportOption.DIALOG;

    public override void OnImportAsset(AssetImportContext ctx)
    {
        if (option == ImportOption.DIALOG)
        {
            DialogContainer container = ScriptableObject.CreateInstance<DialogContainer>();

            string fileText = File.ReadAllText(ctx.assetPath);
            string[] lines = fileText.Split('\n');
            for (int i = 1; i < lines.Length; ++i)
            {
                string[] values = lines[i].Split('\t');
                int id = int.Parse(values[0]);
                Debug.Assert(id == i - 1); //Check the list is ordered correctly
                string text = values[1];
                List<Option> options = new List<Option>();
                for (int j = 2; j + 2 < values.Length; j += 3)
                {
                    string optionText = values[j];
                    if (optionText.Length == 0) continue; //Avoid null options
                    int nextDialogue = int.Parse(values[j + 1]);
                    string OnSelect = values[j + 2].TrimEnd('\r');
                    options.Add(new Option(optionText, nextDialogue, OnSelect));
                }
                container.dialogs.Add(new Dialog.Dialog(text, options));
            }
            ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), container);
        }
        else if (option == ImportOption.CHARFILES)
        {
            Debug.Assert(ctx != null);
            string text = File.ReadAllText(ctx.assetPath);
            string[] lines = text.Split('\n');
            CharacterFileContainer container = ScriptableObject.CreateInstance<CharacterFileContainer>();
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
            ctx.AddObjectToAsset(Path.GetFileNameWithoutExtension(ctx.assetPath), container);
            ctx.SetMainObject(container);
        }
    }
}
