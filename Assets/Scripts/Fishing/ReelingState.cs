using UnityEngine;

public class ReelingState : FishingStateBase
{
    private float fishCatchProgress = 0f;
    private float lineTension = 0f;

    private float reelSpeed = 40f;
    private float tensionIncreasedRate = 35f;
    private float tensionDecreaseRate = 25f;
    private float fishEscapeRate = 5f;

    public ReelingState(FishingManager manager) : base(manager){}

    public override void EnterState()
    {
        manager.uiManager.SetPromptText("Reeling in!");
        manager.uiManager.ShowMiniGameUI(true);

        fishCatchProgress = 0f;
        lineTension = 0f;
        manager.uiManager.UpdateMiniGameUI(fishCatchProgress,lineTension);
    }

    public override void UpdateState()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fishCatchProgress += reelSpeed * Time.deltaTime;
            lineTension += tensionIncreasedRate * Time.deltaTime;
            
        }
        else
        {
            fishCatchProgress -= fishEscapeRate * Time.deltaTime;
            lineTension -= tensionDecreaseRate * Time.deltaTime;
        }


        fishCatchProgress = Mathf.Max(0,fishCatchProgress);
        lineTension = Mathf.Max(0,lineTension);

        manager.uiManager.UpdateMiniGameUI(fishCatchProgress,lineTension);

    
        if(lineTension >= 100f)
        {
            manager.TransitionToState(manager.IdleState);
        }
        else if(fishCatchProgress >= 100f)
        {
            // manager.TransitionToState(manager.IdleState);
            manager.CatchFish();
        }
    }

    public override void ExitState()
    {
        manager.uiManager.ShowMiniGameUI(false);
    }
}
