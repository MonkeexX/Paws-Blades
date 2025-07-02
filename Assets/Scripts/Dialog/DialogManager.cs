using TMPro;
using Tools;
using UnityEngine;


namespace Dialog
{
    [CreateAssetMenu(fileName = "DialogManager", menuName = "Scriptable Objects/Dialog/DialogManager")]
    public class DialogManager : ScriptableObject
    {
        [SerializeField] public static DialogContainer dialogContainer;
        private static Dialog? curDialog;

        public static void Select(int id)
        {
            int nextID = curDialog.Value.options[id].Select();
            if (nextID == -1) { EndDialog(); return; }
            curDialog = dialogContainer.dialogs[nextID];

            MenuManager.Instance.OpenSubMenu(curDialog.Value.options.Count);
            MenuManager.Instance.Display(curDialog.Value);
        }

        public static void StartDialog(DialogContainer dialog)
        {
            dialogContainer = dialog;
            curDialog = dialogContainer.dialogs[0];

            MenuManager.Instance.OpenSubMenu(curDialog.Value.options.Count);
            MenuManager.Instance.Display(curDialog.Value);
        }

        public static void EndDialog()
        {
            dialogContainer = null;
            curDialog = null;

            MenuManager.Instance.CloseMenu();
        }
    }
}