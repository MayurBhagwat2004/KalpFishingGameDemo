using UnityEngine;

public abstract class FishingState
{
    protected FishingState manager;

    public FishingState(FishingState manager)
    {
        this.manager = manager;
    }
    
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
