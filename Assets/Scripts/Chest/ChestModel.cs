using UnityEngine;

namespace ChestSystem
{
    public class ChestModel
    {
        private ChestController chestController;
        private ChestScriptableObject chestScriptableObject;
        public float timeUnlockInSeconds;

        public ChestModel(ChestController _chestController, ChestScriptableObject chestScriptableObject)
        {
            this.chestController = _chestController;
            ResetChestData(chestScriptableObject);
        }

        public void ResetChestData(ChestScriptableObject _chestScriptableObject)
        {
            this.chestScriptableObject = _chestScriptableObject;
            timeUnlockInSeconds = chestScriptableObject.timeInMinutes;
        }

        public int GetRandomGems()
        {
            return Random.Range(chestScriptableObject.minGems, chestScriptableObject.maxGems);
        }

        public int GetRandomCoins()
        {
            return Random.Range(chestScriptableObject.minCoins,chestScriptableObject.maxCoins);
        }

    }
}


