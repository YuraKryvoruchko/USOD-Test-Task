using System.Collections.Generic;
using Core.UI;

namespace Core
{
    public class LoadingState : GameStateBase
    {
        private ISaveLoadSystem _saveLoadSystem;
        private IUISystem _uiSystem;

        public LoadingState(ISaveLoadSystem saveLoadSystem, IUISystem uiSystem, GameStateMachine gameStateMachine) : base(gameStateMachine)
        {
            _saveLoadSystem = saveLoadSystem;
            _uiSystem = uiSystem;
        }

        public override void Init()
        {
        }
        public async override void Process()
        {
            Queue<ILoadingOperation> queue = new Queue<ILoadingOperation>();
            queue.Enqueue(new LoadingOperation(_saveLoadSystem));

            LoadingScreen loadingScreen = _uiSystem.ShowAndGetLoadingScreen(queue);
            await loadingScreen.Load(queue);
            _uiSystem.ReturnLoadingScreen();

            GameStateMachine.ChangeStateTo(GameStateType.Gameplay);
        }
        public override void Deinit()
        {
        }
    }
}
