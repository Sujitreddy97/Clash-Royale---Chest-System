using UnityEngine;

namespace ChestSystem
{
    [CreateAssetMenu(fileName = "ChestScriptable", menuName = "ScriptableObjects/Chest")]
    public class ChestScriptableObject : ScriptableObject
    {
        public ChestTypes chestType;
        public int minCoins, maxCoins;
        public int minGems, maxGems;
        public float timeInMinutes;

        public Sprite chestSprite;
    }
}
