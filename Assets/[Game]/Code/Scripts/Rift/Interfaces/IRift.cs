namespace _Game_.Code.Scripts.Rift.Interfaces
{
    public interface IRift
    {
        public bool IsActive { get; }
        public float Progress { get; }

        void Activate();
        void OnCompleted();
    }
}