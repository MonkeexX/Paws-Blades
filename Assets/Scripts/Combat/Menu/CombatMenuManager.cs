using Dialog;
using Tools;
using UnityEngine;

namespace Combat
{
    public class CombatMenuManager : MenuManager
    {
        public void Display(CombatActor actor) => transform.GetChild(currentID).GetComponent<CombatMenu>().Display(actor);
    }
}