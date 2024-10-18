namespace Core
{
    public class GameStateMachine
    {
        private GameStateBase _currentState;

        private IGameStateFactory _gameStateFactory;

        public GameStateMachine(IGameStateFactory gameStateFactory)
        {
            _gameStateFactory = gameStateFactory;
        }

        public void ChangeStateTo(GameStateType stateType, bool processImmediately = false)
        {
            if (_currentState != null)
                _currentState.Deinit();

            _currentState = _gameStateFactory.GetGameState(stateType);
            _currentState.Init(this);

            if (processImmediately)
                ProcessCurrentState();
        }
        public void ProcessCurrentState()
        {
            if (_currentState == null)
                throw new System.NullReferenceException("You need to set the current state of the game!");

            _currentState.Process();
        }
    }
}
