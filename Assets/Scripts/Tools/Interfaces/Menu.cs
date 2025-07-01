using UnityEngine;

namespace Tools
{
    public abstract class Menu : MonoBehaviour
    {
        public abstract void Display<T>(T toDisplay);
    }
}