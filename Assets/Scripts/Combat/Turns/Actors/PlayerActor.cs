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
            MenuManager.Instance.OpenSubMenu(0);
            MenuManager.Instance.Display(this);
        }

        public override void FinishCombat()
        {
            MenuManager.Instance.Destroy();
        }
    }
}