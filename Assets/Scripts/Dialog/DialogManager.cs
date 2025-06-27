using TMPro;
using UnityEngine;


namespace Dialog
{
    public class DialogManager : MonoBehaviour
    {

        public static DialogManager Instance { get; private set; }

        [SerializeField] private DialogUIHandler UIHandler;
        [SerializeField] public DialogContainer dialogContainer;
        private Dialog curDialog;

        [SerializeField] private TMP_Text dialogText;
        [SerializeField] private TMP_Text option1Text;
        [SerializeField] private TMP_Text option2Text;
        private void Start()
        {
            if (Instance != null) Destroy(this.gameObject);
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            UIHandler.Init(this.transform);
        }

        public void Select(int id)
        {
            curDialog = dialogContainer.dialogs[curDialog.options[id].Select()];
            UIHandler.DisplayDialog(curDialog);
        }

        public void StartDialog(DialogContainer dialog)
        {
            dialogContainer = dialog;
            curDialog = dialogContainer.dialogs[0];
            UIHandler.DisplayDialog(curDialog);
        }
    }
}