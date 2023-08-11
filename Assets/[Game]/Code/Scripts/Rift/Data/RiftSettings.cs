using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game_.Code.Scripts.Rift.Data
{
    public class RiftSettings
    {
        public RiftConfig Config { get; }
        public GameObject Renderer { get; }
        public Collider Collider { get; }

        [ShowInInspector, ReadOnly] public float Progress { get; set; }
        [ShowInInspector, ReadOnly] public bool DidActivated { get; set; }
        [ShowInInspector, ReadOnly] public bool DidProgressActive { get; set; }
        [ShowInInspector, ReadOnly] public bool DidCompleted { get; set; }

        public RiftSettings(
            RiftConfig config,
            GameObject renderer,
            Collider collider)
        {
            Config = config;
            Renderer = renderer;
            Collider = collider;
        }
    }
}