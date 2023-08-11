using System.Collections.Generic;
using _Game_.Code.Scripts.Other;
using _Game_.Code.Scripts.Rift.Interfaces;

namespace _Game_.Code.Scripts.Managers
{
    public class RiftsProgressBarManager
    {
        private readonly List<IRiftProgressBar> _progressBars = new();

        public void AddProgressBar(IRiftProgressBar progressBars)
        {
            if (!_progressBars.Contains(progressBars))
            {
                _progressBars.Add(progressBars);
            }
        }

        public void RemoveProgressBar(IRiftProgressBar progressBars)
        {
            if (_progressBars.Contains(progressBars))
            {
                _progressBars.Remove(progressBars);
            }
        }

        public void ActivateBar(IRift rift)
        {
            var inactiveBar = GetInactiveProgressBar();
            inactiveBar.Active(rift);
        }

        public void InactivateBar(IRift rift)
        {
            var activeBar = GetActiveProgressBar(rift);
            activeBar.Inactive();
        }

        private IRiftProgressBar GetInactiveProgressBar()
        {
            _progressBars.Shuffle();
            var progressBar = _progressBars.Find(bar => !bar.IsActive);
            return progressBar;
        }

        private IRiftProgressBar GetActiveProgressBar(IRift rift)
        {
            var progressBar = _progressBars.Find(bar => bar.Rift == rift);
            return progressBar;
        }
    }
}