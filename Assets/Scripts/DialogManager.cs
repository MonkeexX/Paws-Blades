using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.Events;

namespace Dialog
{
    public struct Option
    {
        public string text {  get; private set; }
        private int nextDialog;
        public Action OnSelect;

        public Option(string text, int nextDialog, Action OnSelect)
        {
            this.text = text;
            this.nextDialog = nextDialog;
            this.OnSelect = OnSelect;
        }

        public int Select()
        {
            OnSelect();
            return nextDialog;
        }
    }
    public struct Dialog
    {
        public string text;
        public List<Option> options;
        public Dialog(string text, List<Option> options)
        {
            this.text = text;
            this.options = options;
        }
    }

    public static class DialogFunctions
    {
        public static Dictionary<string, Action> Functions = new Dictionary<string, Action>
        {
            { "F1", delegate () { Debug.Log("F1"); } },
            { "F2", delegate () { Debug.Log("F2"); } }
        };
    }

    public static class DialogParser
    {
        public static Dictionary<int, Dialog> GetDialogs(TextAsset asset)
        {
            Dictionary<int, Dialog> parsedDialogs = new Dictionary<int, Dialog>();

            string buffer = asset.text;
            string[] lines = buffer.Split('\n');
            for (int i = 1; i < lines.Length; ++i)
            {
                string[] values = lines[i].Split('\t');
                int id = int.Parse(values[0]);
                string text = values[1];
                List<Option> options = new List<Option>();
                for(int j = 2; j + 2 < values.Length; j += 3)
                {
                    string optionText = values[j];
                    if (optionText.Length == 0) continue; //Avoid null options
                    int nextDialogue = int.Parse(values[j + 1]);
                    Action OnSelect = DialogFunctions.Functions[values[j + 2].TrimEnd('\r')];
                    options.Add(new Option(optionText, nextDialogue, OnSelect));
                }
                parsedDialogs.Add(id, new Dialog(text, options));
            }
            return parsedDialogs;
        }
    }
}

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TextAsset asset;
    private Dictionary<int, Dialog.Dialog> dialogs;
    private Dialog.Dialog curDialog;

    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private TMP_Text option1Text;
    [SerializeField] private TMP_Text option2Text;
    private void Start()
    {
        dialogs = Dialog.DialogParser.GetDialogs(asset);
        curDialog = dialogs[0];
        dialogText.text = curDialog.text;
        option1Text.text = curDialog.options[0].text;
        option2Text.text = curDialog.options[1].text;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            curDialog = dialogs[curDialog.options[0].Select()];
            dialogText.text = curDialog.text;
        } else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curDialog = dialogs[curDialog.options[1].Select()];
            dialogText.text = curDialog.text;
        }
    }
}
