using System;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        Starting = 0,
        GenerateMap = 1,
        CenterCamera = 2,
        LoadCards = 3
    }

    public static event Action<GameState> OnBeforeStateChanged;

    public static event Action<GameState> OnAfterStateChanged;

    public GameState State { get; private set; }

    private void Start() => ChangeState(GameState.Starting);

    public void ChangeState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState)
        {
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.GenerateMap:
                GenerateMap();
                break;
            case GameState.CenterCamera:
                CenterCamera();
                break;
            case GameState.LoadCards:
                LoadCards();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState),
                    newState,
                    null);
        }
    }

    private void HandleStarting()
    {
        ChangeState(GameState.GenerateMap);
    }

    private void GenerateMap()
    {
        MapManager.Instance.GenerateMap();

        ChangeState(GameState.CenterCamera);
    }

    private void CenterCamera()
    {
        CameraController.Instance.CenterCamera();

        ChangeState(GameState.LoadCards);
    }

    private void LoadCards()
    {
        CardsManager.Instance.GetPlayerCards();
    }
}
