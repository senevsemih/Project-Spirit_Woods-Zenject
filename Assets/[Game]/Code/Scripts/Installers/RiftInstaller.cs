using System;
using _Game_.Code.Scripts.Rift.Components;
using _Game_.Code.Scripts.Rift.Data;
using UnityEngine;
using Zenject;

namespace _Game_.Code.Scripts.Installers
{
    public class RiftInstaller : MonoInstaller
    {
        [SerializeField] private Settings settings;

        public override void InstallBindings()
        {
            Container.Bind<RiftSettings>().AsSingle().WithArguments(
                settings.config,
                settings.renderer,
                settings.collider);

            Container.Bind<RiftEvents>().AsSingle();
            Container.BindInterfacesTo<RiftVisuals>().AsSingle();
            Container.BindInterfacesTo<RiftProgress>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public RiftConfig config;
            public GameObject renderer;
            public Collider collider;
        }
    }
}