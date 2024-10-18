using System.Collections.Generic;
using Core.UI;
using UnityEngine;

namespace Core
{
    public class LoadingState : GameStateBase
    {
        private ISaveLoadSystem _saveLoadSystem;
        private IUISystem _uiSystem;

        public LoadingState(ISaveLoadSystem saveLoadSystem, IUISystem uiSystem)
        {
            _saveLoadSystem = saveLoadSystem;
            _uiSystem = uiSystem;
        }

        protected override void OnInit()
        {
        }

        public async override void Process()
        {
            Queue<ILoadingOperation> queue = new Queue<ILoadingOperation>();
            LoadingOperation operation = new LoadingOperation(_saveLoadSystem);
            operation.OnLoadGameData += HandleLoadGameData;
            queue.Enqueue(operation);
            queue.Enqueue(new GameInitializationOperation());

            LoadingScreen loadingScreen = _uiSystem.ShowAndGetLoadingScreen(queue);
            await loadingScreen.Load(queue);
            _uiSystem.ReturnLoadingScreen();

            operation.OnLoadGameData -= HandleLoadGameData;

            GameStateMachine.ChangeStateTo(GameStateType.Gameplay, true);
        }
        public override void Deinit()
        {
        }

        private void HandleLoadGameData(GameData gameData)
        {
            Debug.Log("Data is loaded!");
        }
    }
}
