using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState{
        Starting = 0,
        Enum1 = 1,
        Enum2 = 2,
        Enum3 = 3, 
    }

    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State {get; private set;}

    private void Start()=>ChangeState(GameState.Starting);

    public void ChangeState(GameState newState)
    {
        if(State == newState) return;
        OnBeforeStateChanged?.Invoke(newState);
  
        State = newState;
        switch(newState){
            case GameState.Starting:
                HandleStarting();
            break;
            default:
            throw new ArgumentOutOfRangeException(nameof(newState),newState,null);
        }
    }

    private void HandleStarting()
    {
        ChangeState(GameState.Enum1);
    }
}
