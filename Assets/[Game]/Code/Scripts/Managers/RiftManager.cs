using System;
using System.Collections.Generic;
using _Game_.Code.Scripts.Other;
using _Game_.Code.Scripts.Rift.Interfaces;
using Cysharp.Threading.Tasks;
using Zenject;

namespace _Game_.Code.Scripts.Managers
{
    public class RiftManager : IInitializable, IDisposable
    {
        private readonly GameConfig _gameConfig;
        private readonly SignalBus _signalBus;

        private int _currentOpenRiftsCount;

        private readonly List<IRift> _rifts = new();

        public RiftManager(
            GameConfig gameConfig,
            SignalBus signalBus)
        {
            _gameConfig = gameConfig;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            RiftActivateRoutine();
            _signalBus.Subscribe<OnRiftCompleted>(OnRiftCompleted);
        }

        public void Dispose() => _signalBus.Unsubscribe<OnRiftCompleted>(OnRiftCompleted);

        public void AddRift(IRift rift)
        {
            if (!_rifts.Contains(rift))
            {
                _rifts.Add(rift);
            }
        }

        public void RemoveRift(IRift rift)
        {
            if (_rifts.Contains(rift))
            {
                _rifts.Remove(rift);
            }
        }

        private void OnRiftCompleted()
        {
            _currentOpenRiftsCount--;
            RiftActivateRoutine();
        }

        private async void RiftActivateRoutine()
        {
            await UniTask.Delay(_gameConfig.RiftSpawnTime * 1000);

            for (var i = 0; i < _gameConfig.MaxRiftCount; i++)
            {
                if (_currentOpenRiftsCount >= _gameConfig.MaxRiftCount) continue;

                var rift = GetInactiveRift();
                rift.Activate();

                _currentOpenRiftsCount++;
                await UniTask.Delay(_gameConfig.RiftSpawnTime * 1000);
            }
        }

        private IRift GetInactiveRift()
        {
            _rifts.Shuffle();

            var rift = _rifts.Find(r => !r.IsActive);
            return rift;
        }
    }
}