using System;
using System.Collections.Generic;

namespace Core.UI
{
    public interface IUISystem
    {
        void ShowLoadingScreenAndDestroy(Queue<ILoadingOperation> loadingOperations);
    }
    public class UISystem : IUISystem
    {
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

        public async void ShowLoadingScreenAndDestroy(Queue<ILoadingOperation> loadingOperations)
        {
            LoadingScreen loadingScreen = UnityEngine.Object.Instantiate(_arguments.LoadingScreenPrefabs);
            await loadingScreen.Load(loadingOperations);
            UnityEngine.Object.Destroy(loadingScreen);
        }
    }
}
