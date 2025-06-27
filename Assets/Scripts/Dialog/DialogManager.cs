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

            UIHandler.Init();
            curDialog = dialogContainer.dialogs[0];
            UIHandler.DisplayDialog(curDialog);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                curDialog = dialogContainer.dialogs[curDialog.options[0].Select()];
                dialogText.text = curDialog.text;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                curDialog = dialogContainer.dialogs[curDialog.options[1].Select()];
                dialogText.text = curDialog.text;
            }
        }

        public void Select(int id)
        {
            curDialog = dialogContainer.dialogs[curDialog.options[id].Select()];
            UIHandler.DisplayDialog(curDialog);
        }
    }
}