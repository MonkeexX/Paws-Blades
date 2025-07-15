using TMPro;
using UnityEngine;

namespace Combat
{
    public class MagicMenu : CombatMenu
    {
        public override void Display<T>(T toDisplay)
        {
            base.Display<T>(toDisplay);
            PlayerActor actor = toDisplay as PlayerActor;
            Debug.Log(actor.Spells.Length);
            Transform panel = transform.GetChild(0).GetChild(0);
            for(int i = 0; i < actor.Spells.Length; ++i)
            {
                Debug.Assert(panel.GetChild(i).GetChild(0).TryGetComponent(out TMP_Text text), "NO TEXT!");
                Debug.Log(text.text);
                text.text = actor.Spells[i].SpellName;
                Debug.Log(actor.Spells[i].SpellName);
            }
        }
    }
}