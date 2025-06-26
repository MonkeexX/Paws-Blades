using System.Collections.Generic;
using System;
using UnityEngine;

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
}