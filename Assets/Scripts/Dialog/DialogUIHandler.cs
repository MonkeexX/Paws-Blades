using TMPro;
using UnityEngine;

namespace Dialog
{
    public class DialogUIHandler : MonoBehaviour
    {
        [SerializeField] private int currentUI = -1;

        public void DisplayDialog(Dialog dialog) {
            if(currentUI >= 0) transform.GetChild(currentUI).gameObject.SetActive(false);
            currentUI = dialog.options.Count;
            transform.GetChild(currentUI).gameObject.SetActive(true);

            transform.GetChild(currentUI).GetComponent<DialogUI>().DisplayDialog(dialog);
        }

        public void EndDialog()
        {
            transform.GetChild(currentUI).gameObject.SetActive(false);
            currentUI = -1;
        }
    }
}
