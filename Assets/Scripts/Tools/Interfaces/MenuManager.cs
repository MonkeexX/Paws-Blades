using Dialog;
using UnityEngine;

namespace Tools
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] protected int currentID = -1;

        public void OpenSubMenu(int id)
        {
            if (currentID >= 0) transform.GetChild(currentID).gameObject.SetActive(false);
            currentID = id;
            transform.GetChild(currentID).gameObject.SetActive(true);
        }

        public void Display<T1, T2>(T1 toDisplay) where T2 : Menu => transform.GetChild(currentID).GetComponent<T2>().Display(toDisplay);

        public void CloseMenu()
        {
            transform.GetChild(currentID).gameObject.SetActive(false);
            currentID = -1;
        }
    }
}