using UnityEngine.Events;

namespace _Game_.Code.Scripts.Rift.Components
{
    public class RiftEvents
    {
        public readonly UnityEvent OnActivated = new();
        public readonly UnityEvent OnInactivated = new();

        public readonly UnityEvent OnProgressActivated = new();
        public readonly UnityEvent OnProgressInactivated = new();

        public readonly UnityEvent OnCompleted = new();
    }
}