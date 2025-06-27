using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{

    public static class DialogFunctions
    {
        public static Dictionary<string, Action<string[]>> Functions = new Dictionary<string, Action<string[]>>
        {
            { "F1", delegate (string[] input) { Debug.Log("F1"); } },
            { "F2", delegate (string[] input) { Debug.Log("F2"); } },
            { "TP", delegate (string[] input) { LevelManager.Load(input[0]); } },
            { "ADDXP", delegate (string[] input) { throw new NotImplementedException(); } },
            { "REMXP", delegate (string[] input) { throw new NotImplementedException(); } }
        };
    }
}
