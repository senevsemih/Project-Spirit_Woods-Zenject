using System;
using _Game_.Code.Scripts.Managers;
using UnityEngine;
using Zenject;

namespace _Game_.Code.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Settings settings;

        public override void InstallBindings()
        {
            InstallerManagers();
            GameSignalsInstaller.Install(Container);
        }

        private void InstallerManagers()
        {
            Container.Bind<RiftsProgressBarManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<RiftManager>().AsSingle().WithArguments(settings.config);
        }

        [Serializable]
        public class Settings
        {
            public GameConfig config;
        }
    }
}