namespace Core
{
    public interface IGameStateFactory
    {
        GameStateBase GetGameState(GameStateType type);
    }
}
