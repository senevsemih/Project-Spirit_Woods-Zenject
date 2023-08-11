using _Game_.Code.Scripts.Other;
using Zenject;

namespace _Game_.Code.Scripts.Installers
{
    public class GameSignalsInstaller : Installer<GameSignalsInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<OnRiftCompleted>();
        }
    }
}