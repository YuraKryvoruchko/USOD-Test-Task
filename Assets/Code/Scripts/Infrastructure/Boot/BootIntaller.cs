using Zenject;

namespace Core
{
    public class BootIntaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBoot();
        }

        private void BindBoot()
        {
            Container
                .BindInterfacesTo<Boot>()
                .AsSingle();
        }
    }
}
