using TMPro;
using Tools;
using UnityEngine;


namespace Dialog
{
    [CreateAssetMenu(fileName = "DialogManager", menuName = "Scriptable Objects/Dialog/DialogManager")]
    public class DialogManager : ScriptableObject
    {
        [SerializeField] private GameObject MMPrefab;
        [SerializeField] public DialogContainer dialogContainer;
        private Dialog? curDialog;
        public void StartDialog(DialogContainer dialog)
        {
            Instantiate(MMPrefab);

            dialogContainer = dialog;
            curDialog = dialogContainer.dialogs[0];

            MenuManager.Instance.OpenSubMenu(curDialog.Value.options.Count);
            MenuManager.Instance.Display(curDialog.Value);
        }

        public void Select(int id)
        {
            int nextID = curDialog.Value.options[id].Select();
            if (nextID == -1) { EndDialog(); return; }
            curDialog = dialogContainer.dialogs[nextID];

            MenuManager.Instance.OpenSubMenu(curDialog.Value.options.Count);
            MenuManager.Instance.Display(curDialog.Value);
        }

        public void EndDialog()
        {
            dialogContainer = null;
            curDialog = null;

            MenuManager.Instance.CloseMenu();
            MenuManager.Instance.Destroy();
        }
    }
}