namespace _Game_.Code.Scripts.Rift.Interfaces
{
    public interface IRiftProgressBar
    {
        public IRift Rift { get; set; }
        public bool IsActive { get; set; }

        void Active(IRift rift);
        void Update();
        void Inactive();
    }
}