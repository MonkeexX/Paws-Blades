using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{

    public static class DialogFunctions
    {
        public static Dictionary<string, Action> Functions = new Dictionary<string, Action>
        {
            { "F1", delegate () { Debug.Log("F1"); } },
            { "F2", delegate () { Debug.Log("F2"); } }
        };
    }
}
