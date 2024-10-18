using UnityEngine;
using Zenject;
using Core.UI;

namespace Core.Infrastructure 
{ 
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private UISystem.ConstructorArguments _uiSystemArguments;
        [SerializeField] private GameStateFactory.ConstructorArguments _gameStateFactoryArguments;

        public override void InstallBindings()
        {
            BindSaveLoadSystem();
            BindUISystem();
            BindGamePlaySessionTimer();
            BindGameStateFactory();
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
        private void BindGamePlaySessionTimer()
        {
            Container
                .BindInterfacesAndSelfTo<GamePlaySessionTimer>()
                .AsSingle();
        }
        private void BindGameStateFactory()
        {
            Container
                .BindInterfacesTo<GameStateFactory>()
                .AsSingle()
                .WithArguments(_gameStateFactoryArguments);
        }
        private void BindGameStateMachine()
        {
            Container
                .Bind<GameStateMachine>()
                .AsSingle();
        }
    }
}
