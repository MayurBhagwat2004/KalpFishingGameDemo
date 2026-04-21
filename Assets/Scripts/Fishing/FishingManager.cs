using UnityEngine;

public class FishingManager : MonoBehaviour
{
    private FishingStateBase currentState;

    public IdleState IdleState{get; private set;}
    public CastingState CastingState{get; private set;}
    public WaitingState WaitingState{get; private set;}
    public ReelingState ReelingState{get; private set;}

    [Header("Physical References")]
    public Transform bobber;
    public Transform castPoint;

    [Header("UI Reference")]
    public UIManager uiManager;

    [Header("Fish Database")]
    public FishData[] availableFish;
    
    [HideInInspector]
    public string lastCatchMessage = "";
    
    void Start()
    {
        IdleState = new IdleState(this);
        CastingState = new CastingState(this);
        WaitingState = new WaitingState(this);
        ReelingState = new ReelingState(this);
        
        TransitionToState(IdleState);
    }
    void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void TransitionToState(FishingStateBase newState)
    {
        if(currentState != null)
        {
            currentState.ExitState();
        }

        currentState = newState;
        currentState.EnterState();
    }

    public void CatchFish()
    {
        if(availableFish.Length == 0) return;

        int randomIndex = Random.Range(0, availableFish.Length);
        FishData caughtFish = availableFish[randomIndex];

        lastCatchMessage = $"You caught a {caughtFish.rarity} {caughtFish.fishName}";
        Debug.Log(lastCatchMessage);

        TransitionToState(IdleState);
    }
}
