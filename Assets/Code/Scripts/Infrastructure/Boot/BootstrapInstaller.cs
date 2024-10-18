using UnityEngine;
using Zenject;
using Core.UI;

namespace Core.Infrastructure 
{ 
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private UISystem.ConstructorArguments _uiSystemArguments;

        public override void InstallBindings()
        {
            BindSaveLoadSystem();
            BindUISystem();
            BindGameStateMachine();
        }

        private void BindSaveLoadSystem()
        {
            Container
                .Bind<ISaveLoadSystem>()
                .To<SaveLoadSystem>()
                .AsSingle();
        }
        private void BindUISystem()
        {
            Container
                .Bind<IUISystem>()
                .To<UISystem>()
                .AsSingle()
                .WithArguments(_uiSystemArguments);
        }
        private void BindGameStateMachine()
        {
            Container
                .Bind<GameStateMachine>()
                .AsSingle();
        }
    }
}
