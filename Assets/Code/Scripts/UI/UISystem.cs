using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    public interface IUISystem
    {
        LoadingScreen ShowAndGetLoadingScreen(Queue<ILoadingOperation> loadingOperations);
        void ReturnLoadingScreen();
    }
    public class UISystem : IUISystem
    {
        private LoadingScreen _currentLoadingScreen;

        private ConstructorArguments _arguments;

        [Serializable]
        public class ConstructorArguments
        {
            public LoadingScreen LoadingScreenPrefabs;
        }

        public UISystem(ConstructorArguments arguments)
        {
            _arguments = arguments;
        }

        public LoadingScreen ShowAndGetLoadingScreen(Queue<ILoadingOperation> loadingOperations)
        {
            if(_currentLoadingScreen != null)
                return _currentLoadingScreen;

            _currentLoadingScreen = UnityEngine.Object.Instantiate(_arguments.LoadingScreenPrefabs);
            return _currentLoadingScreen;
        }
        public void ReturnLoadingScreen()
        {
            UnityEngine.Object.Destroy(_currentLoadingScreen);
        }
    }
}
