using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState{
        Starting = 0,
        GenerateMap = 1,
        Enum2 = 2,
        Enum3 = 3, 
    }

    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State {get; private set;}

    private void Start()=>ChangeState(GameState.Starting);

    public void ChangeState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState);
       
  
        State = newState;
        switch(newState){
            case GameState.Starting:
                HandleStarting();
            break;
            case GameState.GenerateMap:
                GenerateMap();
            break;
            default:
            throw new ArgumentOutOfRangeException(nameof(newState),newState,null);
        }
    }

    private void HandleStarting()
    {
        ChangeState(GameState.GenerateMap);
    }

    private void GenerateMap()
    {
            MapManager.Instance.GenerateMap();
            ChangeState(GameState.Enum2);
    }
}
