using TMPro;
using UnityEngine;

namespace Dialog
{
    public class DialogMenu : MonoBehaviour
    {
        [SerializeField] TMP_Text mainDialog;
        [SerializeField] TMP_Text[] options;

        public void DisplayDialog(Dialog dialog)
        {
            mainDialog.text = dialog.text;
            for (int i = 0; i < dialog.options.Count; i++)
                options[i].text = dialog.options[i].text;
        }

        public void Select(int id) => DialogManager.Instance.Select(id);
        public void CloseDialog() => DialogManager.Instance.EndDialog();
    }
}