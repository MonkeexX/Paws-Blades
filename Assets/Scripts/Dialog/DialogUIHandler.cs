using TMPro;
using UnityEngine;

namespace Dialog
{
    [CreateAssetMenu(fileName ="DialogUIHandler", menuName ="Scriptable Objects/DialogUIHandler")]
    public class DialogUIHandler : ScriptableObject
    {
        [SerializeField] private GameObject[] UIs;
        [SerializeField] private Object[] instantiatedUIs;
        [SerializeField] private Object currentUI;

        public void Init(Transform transform)
        {
            instantiatedUIs = new GameObject[UIs.Length];
            for (int i = 0; i < UIs.Length; ++i)
            {
                instantiatedUIs[i] = Instantiate(UIs[i], transform);
                (instantiatedUIs[i] as GameObject).SetActive(false);
            }
        }
        public void DisplayDialog(Dialog dialog) {
            if(currentUI != null) ((GameObject)currentUI).SetActive(false);
            currentUI = instantiatedUIs[dialog.options.Count];
            ((GameObject)currentUI).SetActive(true);

            ((GameObject)currentUI).GetComponent<DialogUI>().DisplayDialog(dialog);
        }
    }
}
