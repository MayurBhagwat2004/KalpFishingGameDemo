using UnityEngine;

public class CastingState : FishingStateBase
{
    private float castDuration = 2f;
    private float timer;

    public CastingState(FishingManager manager) : base(manager){}

    public override void EnterState()
    {
        Debug.Log("Entering Casting State! Throwing the bobber");
    
        timer = castDuration;
        AudioManager.Instance.PlaySfx(AudioManager.Instance.castLineClip);

        if(manager.bobber != null)
        {
            manager.bobber.position += Vector3.forward * 5f;
        }
    }

    public override void UpdateState()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Debug.Log("Bobber hit the water!");
            manager.TransitionToState(manager.WaitingState);
        }
    }

    public override void ExitState()
    {
        Debug.Log("Leaving Casting State");
    }

 
}
