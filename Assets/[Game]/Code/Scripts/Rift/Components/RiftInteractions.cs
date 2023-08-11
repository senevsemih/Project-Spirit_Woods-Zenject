using _Game_.Code.Scripts.Rift.Data;
using _Game_.Code.Scripts.Rift.Interfaces;
using UnityEngine;
using Zenject;

namespace _Game_.Code.Scripts.Rift.Components
{
    public class RiftInteractions : MonoBehaviour
    {
        private RiftSettings _settings;
        private RiftEvents _events;

        [Inject]
        public void Construct(
            RiftSettings settings,
            RiftEvents events)
        {
            _settings = settings;
            _events = events;
        }

        private void OnEnable()
        {
            _events.OnActivated.AddListener(OnActivated);
            _events.OnInactivated.AddListener(OnInactivated);
        }

        private void OnDisable()
        {
            _events.OnActivated.RemoveListener(OnActivated);
            _events.OnInactivated.RemoveListener(OnInactivated);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IRiftInteractable interactable) && _settings.DidActivated)
            {
                _events.OnProgressActivated?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IRiftInteractable interactable) && _settings.DidActivated)
            {
                _events.OnProgressInactivated?.Invoke();
            }
        }

        private void OnActivated() => SetCollider(true);
        private void OnInactivated() => SetCollider(false);
        private void SetCollider(bool value) => _settings.Collider.enabled = value;
    }
}