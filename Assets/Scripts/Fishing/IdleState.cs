using UnityEngine;

public class IdleState : FishingStateBase
{
    public IdleState(FishingManager manager) : base(manager){}


    public override void EnterState()
    {
        manager.uiManager.SetPromptText("Press [Space] to cast");

        if(manager.lastCatchMessage != null)
        {
            manager.uiManager.SetPromptText(manager.lastCatchMessage+ "\n Press [Space] to cast again");
            manager.lastCatchMessage = "";
        }
        else
        {
            manager.uiManager.SetPromptText("Press [Space] to cast");
        }
        
        if(manager.bobber != null && manager.castPoint != null)
        {
            manager.bobber.position = manager.castPoint.position;
        }
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            manager.TransitionToState(manager.CastingState);            
        }
    }

    public override void ExitState()
    {
        Debug.Log("Leaving Idle State");
    }
}
