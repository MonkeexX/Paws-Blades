using TMPro;
using Tools;
using UnityEngine;

namespace Dialog
{
    public class DialogMenuManager : MenuManager
    {
        public void DisplayDialog(Dialog dialog) => transform.GetChild(currentID).GetComponent<DialogMenu>().Display(dialog);
    }
}
