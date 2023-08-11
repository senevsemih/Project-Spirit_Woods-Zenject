using System;
using _Game_.Code.Scripts.Rift.Data;
using UnityEngine;
using Zenject;

namespace _Game_.Code.Scripts.Rift.Components
{
    public class RiftProgress : IInitializable, ITickable, IDisposable
    {
        private readonly RiftSettings _settings;
        private readonly RiftEvents _events;

        private const float MIN = 0f;
        private const float MAX = 100f;

        public RiftProgress(
            RiftSettings settings,
            RiftEvents events)
        {
            _settings = settings;
            _events = events;
        }

        public void Initialize()
        {
            _events.OnProgressActivated.AddListener(ProgressActive);
            _events.OnProgressInactivated.AddListener(ProgressInactive);
        }

        public void Dispose()
        {
            _events.OnProgressActivated.RemoveListener(ProgressActive);
            _events.OnProgressInactivated.RemoveListener(ProgressInactive);
        }

        public void Tick()
        {
            if (_settings.DidProgressActive && !_settings.DidCompleted)
            {
                UpdateProgress();
            }
        }

        private void ProgressActive() => _settings.DidProgressActive = true;
        private void ProgressInactive() => _settings.DidProgressActive = false;

        private void UpdateProgress()
        {
            _settings.Progress += _settings.Config.ProgressSpeed * Time.deltaTime;
            _settings.Progress = Mathf.Clamp(_settings.Progress, MIN, MAX);

            if (_settings.Progress >= MAX)
            {
                _events.OnCompleted?.Invoke();
            }
        }
    }
}