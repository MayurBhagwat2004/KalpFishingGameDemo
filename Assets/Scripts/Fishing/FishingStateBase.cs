public abstract class FishingStateBase
{
    protected FishingManager manager;

    public FishingStateBase(FishingManager manager)
    {
        this.manager = manager;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
