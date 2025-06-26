using TMPro;
using UnityEngine;


namespace Dialog
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] public DialogContainer dialogContainer;
        private Dialog curDialog;

        [SerializeField] private TMP_Text dialogText;
        [SerializeField] private TMP_Text option1Text;
        [SerializeField] private TMP_Text option2Text;
        private void Start()
        {
            Debug.Log(dialogContainer.dialogs.Count);
            curDialog = dialogContainer.dialogs[0];
            dialogText.text = curDialog.text;
            option1Text.text = curDialog.options[0].text;
            option2Text.text = curDialog.options[1].text;
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
    }
}