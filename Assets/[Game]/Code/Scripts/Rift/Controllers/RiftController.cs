using _Game_.Code.Scripts.Managers;
using _Game_.Code.Scripts.Other;
using _Game_.Code.Scripts.Rift.Components;
using _Game_.Code.Scripts.Rift.Data;
using _Game_.Code.Scripts.Rift.Interfaces;
using UnityEngine;
using Zenject;

namespace _Game_.Code.Scripts.Rift.Controllers
{
    public class RiftController : MonoBehaviour, IRift
    {
        private RiftSettings _settings;
        private RiftEvents _events;

        private RiftManager _riftManager;
        private RiftsProgressBarManager _riftsProgressBarManager;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(
            RiftSettings settings,
            RiftEvents events,
            RiftManager riftManager,
            RiftsProgressBarManager riftsProgressBarManager,
            SignalBus signalBus)
        {
            _settings = settings;
            _events = events;
            _riftManager = riftManager;
            _riftsProgressBarManager = riftsProgressBarManager;
            _signalBus = signalBus;
        }

        public bool IsActive => _settings.DidActivated;
        public float Progress => _settings.Progress;

        private void Start()
        {
            _riftManager.AddRift(this);
            _events.OnInactivated?.Invoke();
        }

        private void OnEnable() => _events.OnCompleted.AddListener(OnCompleted);
        private void OnDisable() => _events.OnCompleted.RemoveListener(OnCompleted);
        private void OnDestroy() => _riftManager.RemoveRift(this);

        public void Activate()
        {
            _settings.Progress = 0;

            _settings.DidActivated = true;
            _settings.DidProgressActive = false;
            _settings.DidCompleted = false;

            _events.OnActivated?.Invoke();
            _riftsProgressBarManager.ActivateBar(this);
        }

        public void OnCompleted()
        {
            _settings.DidActivated = false;
            _settings.DidProgressActive = false;
            _settings.DidCompleted = true;

            _events.OnInactivated?.Invoke();
            _riftsProgressBarManager.InactivateBar(this);
            _signalBus.Fire<OnRiftCompleted>();
        }
    }
}