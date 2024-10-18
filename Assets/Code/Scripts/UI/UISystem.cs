using System;
using System.Collections.Generic;

namespace Core.UI
{
    public interface IUISystem
    {
        T ShowWindowFromPrefab<T>(T windowBasePrefab) where T : WindowBase;
        void HideLastWindow();

        LoadingScreen ShowAndGetLoadingScreen(Queue<ILoadingOperation> loadingOperations);
        void ReturnLoadingScreen();
    }

    public class UISystem : IUISystem
    {
        private LoadingScreen _currentLoadingScreen;

        private Stack<WindowBase> _windows;

        private ConstructorArguments _arguments;

        [Serializable]
        public class ConstructorArguments
        {
            public LoadingScreen LoadingScreenPrefabs;
        }

        public UISystem(ConstructorArguments arguments)
        {
            _arguments = arguments;
            _windows = new Stack<WindowBase>();
        }

        public T ShowWindowFromPrefab<T>(T windowBasePrefab) where T : WindowBase
        {
            T window = UnityEngine.Object.Instantiate(windowBasePrefab);

            if(_windows.Count > 0)
                _windows.Peek().Hide();

            _windows.Push(window);
            window.Show();

            return window;
        }
        public void HideLastWindow()
        {
            if (_windows.Count == 0)
                return;

            WindowBase window = _windows.Pop();
            window.Hide();
            UnityEngine.Object.Destroy(window.gameObject);

            _windows.Peek().Show();
        }

        public LoadingScreen ShowAndGetLoadingScreen(Queue<ILoadingOperation> loadingOperations)
        {
            if(_currentLoadingScreen == null)
                _currentLoadingScreen = UnityEngine.Object.Instantiate(_arguments.LoadingScreenPrefabs);

            return _currentLoadingScreen;
        }
        public void ReturnLoadingScreen()
        {
            UnityEngine.Object.Destroy(_currentLoadingScreen.gameObject);
        }
    }
}
