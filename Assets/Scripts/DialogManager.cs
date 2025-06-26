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
    [Serializable]
    public struct Option
    {
        [SerializeField] public string text;
        [SerializeField] public int nextDialog;
        [SerializeField] public string OnSelect;

        public Option(string text, int nextDialog, string OnSelect)
        {
            this.text = text;
            this.nextDialog = nextDialog;
            this.OnSelect = OnSelect;
        }

        public int Select()
        {
            DialogFunctions.Functions[OnSelect]();
            return nextDialog;
        }
    }
    [Serializable]
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
}

public class DialogManager : MonoBehaviour
{
    [SerializeField] public DialogContainer dialogContainer;
    private Dialog.Dialog curDialog;

    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private TMP_Text option1Text;
    [SerializeField] private TMP_Text option2Text;
    private void Start()
    {
        Debug.Log(dialogContainer.dialogs.Count);
        curDialog = dialogContainer.dialogs[0];
        dialogText.text = curDialog.text;
        option1Text.text = curDialog.options[0].text;
        option2Text.text = curDialog.options[1].text;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            curDialog = dialogContainer.dialogs[curDialog.options[0].Select()];
            dialogText.text = curDialog.text;
        } else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curDialog = dialogContainer.dialogs[curDialog.options[1].Select()];
            dialogText.text = curDialog.text;
        }
    }
}
