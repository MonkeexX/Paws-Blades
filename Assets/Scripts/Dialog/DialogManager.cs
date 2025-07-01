using TMPro;
using Tools;
using UnityEngine;


namespace Dialog
{
    public class DialogManager : MonoBehaviour
    {

        public static DialogManager Instance { get; private set; }

        [SerializeField] private MenuManager UIHandler;
        [SerializeField] public DialogContainer dialogContainer;
        private Dialog? curDialog;

        [SerializeField] private TMP_Text dialogText;
        [SerializeField] private TMP_Text option1Text;
        [SerializeField] private TMP_Text option2Text;
        private void Start()
        {
            if (Instance != null) Destroy(this.gameObject);
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        public void Select(int id)
        {
            int nextID = curDialog.Value.options[id].Select();
            if (nextID == -1) { EndDialog(); return; }
            curDialog = dialogContainer.dialogs[nextID];

            UIHandler.OpenSubMenu(curDialog.Value.options.Count);
            UIHandler.Display<Dialog, DialogMenu>(curDialog.Value);
        }

        public void StartDialog(DialogContainer dialog)
        {
            dialogContainer = dialog;
            curDialog = dialogContainer.dialogs[0];

            UIHandler.OpenSubMenu(curDialog.Value.options.Count);
            UIHandler.Display<Dialog, DialogMenu>(curDialog.Value);
        }

        public void EndDialog()
        {
            dialogContainer = null;
            curDialog = null;

            UIHandler.CloseMenu();
        }
    }
}