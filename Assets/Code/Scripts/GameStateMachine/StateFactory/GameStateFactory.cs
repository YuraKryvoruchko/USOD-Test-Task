using System.Collections.Generic;
using System;
using Core.UI;
using Zenject;
using System.ComponentModel;

namespace Core
{
    public class GameStateFactory : IGameStateFactory
    {
        private DiContainer _diContainer;

        private Dictionary<GameStateType, GameStateBase> _stateDictionary;

        private ConstructorArguments _constructorArguments;

        [Serializable]
        public class ConstructorArguments
        {
            public GameUI GameUIPrefab;
        }

        public GameStateFactory(DiContainer diContainer, ConstructorArguments constructorArguments)
        {
            _diContainer = diContainer;
            _constructorArguments = constructorArguments;
            _stateDictionary = new Dictionary<GameStateType, GameStateBase>();

            _stateDictionary = new Dictionary<GameStateType, GameStateBase>()
            {
                { GameStateType.Loading, _diContainer.Instantiate<LoadingState>() },
                { GameStateType.Gameplay, _diContainer.Instantiate<GamePlayState>(new object[] {_constructorArguments.GameUIPrefab }) }
            };
        }

        public GameStateBase GetGameState(GameStateType type)
        {
            return _stateDictionary[type];
        }
    }
}
