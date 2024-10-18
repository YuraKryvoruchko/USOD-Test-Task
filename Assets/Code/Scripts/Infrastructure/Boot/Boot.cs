using Zenject;

namespace Core
{
    public class Boot : IInitializable
    {
        private GameStateMachine _gameStateMachine;

        public Boot(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Initialize()
        {
            _gameStateMachine.ChangeStateTo(GameStateType.Loading);
            _gameStateMachine.ProcessCurrentState();
        }
    }
}
