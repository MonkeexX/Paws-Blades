using Dialog;
using UnityEngine;

namespace Tools
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager Instance { get; private set; }

        [SerializeField] protected int currentID = -1;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Instance set");
        }

        public void OpenSubMenu(int id)
        {
            if (currentID >= 0) transform.GetChild(currentID).gameObject.SetActive(false);
            currentID = id;
            transform.GetChild(currentID).gameObject.SetActive(true);
        }

        public void Display<T1>(T1 toDisplay) => transform.GetChild(currentID).GetComponent<Menu>().Display(toDisplay);

        public void CloseMenu()
        {
            transform.GetChild(currentID).gameObject.SetActive(false);
            currentID = -1;
        }

        public void Destroy() => Destroy(gameObject);
    }
}