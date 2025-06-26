using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
    public static class DialogImport
    {
        public static DialogContainer ImportDialog(string rawText)
        {
            DialogContainer container = ScriptableObject.CreateInstance<DialogContainer>();

            string[] lines = rawText.Split('\n');
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
                container.dialogs.Add(new Dialog(text, options));
            }

            return container;
        }
    }
}