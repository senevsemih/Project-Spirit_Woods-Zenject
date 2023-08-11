using System;
using _Game_.Code.Scripts.Rift.Data;
using Zenject;

namespace _Game_.Code.Scripts.Rift.Components
{
    public class RiftVisuals : IInitializable, IDisposable
    {
        private readonly RiftSettings _settings;
        private readonly RiftEvents _events;

        public RiftVisuals(
            RiftSettings settings,
            RiftEvents events)
        {
            _settings = settings;
            _events = events;
        }

        public void Initialize()
        {
            _events.OnActivated.AddListener(OnActivated);
            _events.OnInactivated.AddListener(OnInactivated);
        }

        public void Dispose()
        {
            _events.OnActivated.RemoveListener(OnActivated);
            _events.OnInactivated.RemoveListener(OnInactivated);
        }

        private void OnActivated() => SetRenderer(true);
        private void OnInactivated() => SetRenderer(false);
        private void SetRenderer(bool value) => _settings.Renderer.SetActive(value);
    }
}