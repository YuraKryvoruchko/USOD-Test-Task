using Core.UI;

namespace Core
{
    public class LoadingState : GameStateBase
    {
        private ISaveLoadSystem _saveLoadSystem;
        private IUISystem _uiSystem;

        public LoadingState(ISaveLoadSystem saveLoadSystem, IUISystem uISystem)
        {
            _saveLoadSystem = saveLoadSystem;
        }

        public override void Init()
        {
            throw new System.NotImplementedException();
        }
        public override void Process()
        {
            throw new System.NotImplementedException();
        }
        public override void Deinit()
        {
            throw new System.NotImplementedException();
        }
    }
}
