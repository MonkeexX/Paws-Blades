using UnityEngine;

namespace Combat
{
    public class CombatMenu : Tools.Menu
    {

        public override void Display<T>(T toDisplay)
        {
            Debug.Log("Display");
        }
    }
}