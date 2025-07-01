using TMPro;
using UnityEngine;

namespace Dialog
{
    public class DialogMenu : Tools.Menu
    {
        [SerializeField] TMP_Text mainDialog;
        [SerializeField] TMP_Text[] options;

        public override void Display<T>(T toDisplay)
        {
            Dialog? dialog = toDisplay as Dialog?;
            mainDialog.text = dialog.Value.text;
            for (int i = 0; i < dialog.Value.options.Count; i++)
                options[i].text = dialog.Value.options[i].text;
        }

        public void Select(int id) => DialogManager.Select(id);
        public void CloseDialog() => DialogManager.EndDialog();
    }
}