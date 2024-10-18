namespace Core
{
    public class GameStateMachine
    {
        private GameStateBase _currentState;

        private GameStateBase _loadingState;
        private GameStateBase _gameState;

        public void ChangeState(GameStateBase nextGameState)
        {
            if (_currentState != null)
                _currentState.Deinit();

            _currentState = nextGameState;
            _currentState.Init();
        }
        public void ProcessCurrentState()
        {
            if (_currentState == null)
                throw new System.NullReferenceException("You need to set the current state of the game!");

            _currentState.Process();
        }
    }

    public abstract class GameStateBase
    {
        public abstract void Init();
        public abstract void Process();
        public abstract void Deinit();
    }
}
