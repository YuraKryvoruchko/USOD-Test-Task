using System.Collections.Generic;
using Core.UI;

namespace Core
{
    public enum GameStateType
    {
        Loading,
        Gameplay
    }
    public class GameStateMachine
    {
        private GameStateBase _currentState;

        private Dictionary<GameStateType, GameStateBase> _stateDictionary;

        public GameStateMachine(ISaveLoadSystem saveLoadSystem, IUISystem uiSystem)
        {
            _stateDictionary = new Dictionary<GameStateType, GameStateBase>()
            { 
                { GameStateType.Loading, new LoadingState(saveLoadSystem, uiSystem, this) }
            };
        }

        public void ChangeStateTo(GameStateType stateType)
        {
            if (_currentState != null)
                _currentState.Deinit();

            _currentState = _stateDictionary[stateType];
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
        protected GameStateMachine GameStateMachine { get; private set; }

        public GameStateBase(GameStateMachine gameStateMachine)
        {
            GameStateMachine = gameStateMachine;
        }

        public abstract void Init();
        public abstract void Process();
        public abstract void Deinit();
    }
}
