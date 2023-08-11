using _Game_.Code.Scripts.Managers;
using _Game_.Code.Scripts.Rift.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Game_.Code.Scripts.Rift.UI
{
    public class RiftProgressBar : MonoBehaviour, IRiftProgressBar
    {
        [SerializeField] private Image image;

        private RiftsProgressBarManager _riftsProgressBarManager;

        private const float MIN = 0f;
        private const float MAX = 100f;

        public IRift Rift { get; set; }
        public bool IsActive { get; set; }

        [Inject]
        public void Construct(
            RiftsProgressBarManager riftsProgressBarManager)
        {
            _riftsProgressBarManager = riftsProgressBarManager;
            _riftsProgressBarManager.AddProgressBar(this);
        }

        private void Start() => Inactive();

        public void Update()
        {
            if (!IsActive) return;
            UpdateFill();
        }

        public void Active(IRift rift)
        {
            Rift = rift;
            IsActive = true;
            SetBody(true);
        }

        public void Inactive()
        {
            SetBody(false);
            IsActive = false;
            Rift = null;
        }

        private void SetBody(bool value) => gameObject.SetActive(value);
        private void UpdateFill() => image.fillAmount = Mathf.InverseLerp(MIN, MAX, Rift.Progress);
        private void OnDestroy() => _riftsProgressBarManager.RemoveProgressBar(this);
    }
}