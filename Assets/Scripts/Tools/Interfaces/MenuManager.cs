using Dialog;
using UnityEngine;

namespace Tools
{
    public class MenuManager : MonoBehaviour
    {
        public class Generic<T>
        {
            public T value;
        }


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

        public virtual void OpenSubMenu(int id)
        {
            if (currentID >= 0) transform.GetChild(currentID).gameObject.SetActive(false);
            currentID = id;
            transform.GetChild(currentID).gameObject.SetActive(true);
        }

        public void Display<T>(T toDisplay) => transform.GetChild(currentID).GetComponent<Menu>().Display(toDisplay);

        public void OpenAndDisplay<T>(int id, T toDisplay)
        {
            OpenSubMenu(id);
            Display<T>(toDisplay);
        }

        public void CloseMenu()
        {
            transform.GetChild(currentID).gameObject.SetActive(false);
            currentID = -1;
        }

        public void Destroy() => Destroy(gameObject);
    }
}