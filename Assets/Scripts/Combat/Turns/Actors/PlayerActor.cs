using Tools;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "PlayerActor", menuName = "Scriptable Objects/Combat/Actors/PlayerActor")]
    public class PlayerActor : CombatActor
    {
        [SerializeField] GameObject MMPrefab;
        [SerializeField] MenuManager combatMenu;

        public override void StartCombat()
        {
            GameObject.Instantiate(MMPrefab);
        }

        public override void PromptChoice()
        {
            CombatMenuManager.Instance.OpenSubMenu(0);
            CombatMenuManager.Instance.Display(this);
        }

        public override void FinishCombat()
        {
            CombatMenuManager.Instance.Destroy();
        }
    }
}