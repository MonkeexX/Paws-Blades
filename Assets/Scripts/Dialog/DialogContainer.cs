using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
    [Serializable]
    public class DialogContainer : ScriptableObject
    {
        [SerializeField]
        public List<Dialog> dialogs = new List<Dialog>();
    }
}