using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogContainer : ScriptableObject
{
    [SerializeField]
    public List<Dialog.Dialog> dialogs = new List<Dialog.Dialog>();
}
