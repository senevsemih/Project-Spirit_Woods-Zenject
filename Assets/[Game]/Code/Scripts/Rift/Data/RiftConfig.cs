using UnityEngine;

namespace _Game_.Code.Scripts.Rift.Data
{
    [CreateAssetMenu(menuName = "Game/Rift Config", fileName = "Rift Config")]
    public class RiftConfig : ScriptableObject
    {
        [SerializeField] private float progressSpeed;
        public float ProgressSpeed => progressSpeed;
    }
}