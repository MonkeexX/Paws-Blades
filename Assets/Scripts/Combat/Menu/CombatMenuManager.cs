using Combat;
using UnityEngine;

public class CombatMenuManager : Tools.MenuManager
{
    public CombatActor actorToShow;

    public override void OpenSubMenu(int id)
    {
        base.OpenSubMenu(id);
        Display(actorToShow);
    }

    public void SetActorToShow(CombatActor actorToShow) => this.actorToShow = actorToShow;
}
