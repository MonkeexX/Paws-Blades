using TMPro;
using UnityEngine;

namespace Combat
{
    public class MagicMenu : CombatMenu
    {
        public override void Display<T>(T toDisplay)
        {
            PlayerActor actor = toDisplay as PlayerActor;
            for(int i = 0; i < actor.Spells.Length; ++i)
            {
                transform.GetChild(i).gameObject.GetComponent<TMP_Text>().SetText(actor.Spells[i].SpellName);
            }
        }
    }
}