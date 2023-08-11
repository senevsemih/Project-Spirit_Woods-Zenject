using UnityEngine;

namespace _Game_.Code.Scripts
{
    [CreateAssetMenu(menuName = "Game/Game Config", fileName = "Game Config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private int riftSpawnTime;
        [SerializeField] private int maxRiftCount;
        
        public int RiftSpawnTime => riftSpawnTime;
        public int MaxRiftCount => maxRiftCount;
    }
}