using System.Collections.Generic;
using System;
using UnityEngine;
using System.Diagnostics.Contracts;

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
            Debug.Log(this.OnSelect);
            foreach (string fn in this.OnSelect.Split(';'))
            {
                string[] parts = fn.Replace(" ", "").Split(',');
                DialogFunctions.Functions[parts[0]](parts[1..]);
            }
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