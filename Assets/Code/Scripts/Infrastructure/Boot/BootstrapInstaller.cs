using Zenject;

namespace Core.Infrastructure 
{ 
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSaveLoadSystem();
        }

        private void BindSaveLoadSystem()
        {
            Container
                .Bind<ISaveLoadSystem>()
                .To<SaveLoadSystem>()
                .AsSingle();
        }
    }
}
