using UnityEditor.iOS.Xcode;
using UnityEngine;

public class WaitingState : FishingStateBase
{
    private float waitTimer;
    private bool isFishOnLine;
    private float reactionWindow = 2f;
    private float reactionTimer;
    public WaitingState(FishingManager manager) : base(manager){}

    public override void EnterState()
    {
        manager.uiManager.SetPromptText("Waiting for a bite.....");

        waitTimer = Random.Range(3f,7f);
        isFishOnLine = false;
    }

    public override void UpdateState()
    {
        if (!isFishOnLine)
        {
            waitTimer -= Time.deltaTime;

            if(waitTimer <= 0)
            {
                TriggerFishBite();
            }
        }
        else
        {
            reactionTimer -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Hooked it!");
                manager.TransitionToState(manager.ReelingState);
            }
            else if(reactionTimer <= 0)
            {
                Debug.Log("Oh no, The fish got away");
                AudioManager.Instance.PlaySfx(AudioManager.Instance.catchFailClip);
                manager.TransitionToState(manager.IdleState);
            }
        }
    }

    private void TriggerFishBite()
    {
        isFishOnLine = true;
        reactionTimer = reactionWindow;

        manager.uiManager.SetPromptText("Fish Bite! Press [Space] Quickly!");

        AudioManager.Instance.PlaySfx(AudioManager.Instance.fishBiteClip);

        if(manager.bobber != null)
        {
            manager.bobber.position += Vector3.down * 0.5f;
        }
    }

    public override void ExitState()
    {
        Debug.Log("Leaving Waiting State");
    }
}
