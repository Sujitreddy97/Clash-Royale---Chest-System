
using System;
using UnityEngine;
using UnityEngine.XR;

namespace ChestSystem
{
    public class ChestController
    {
        private ChestModel chestModel;
        private ChestView chestView;
        private ChestScriptableObject chestScriptableObject;

        public ChestController(ChestScriptableObject _chestScriptableObject, ChestView _chestView, Transform parent)
        {
            this.chestScriptableObject = _chestScriptableObject;
            this.chestModel = new ChestModel(this, _chestScriptableObject);
            this.chestView = GameObject.Instantiate<ChestView>(_chestView, parent);
            chestView.SetChestController(this);
        }

        public void Enable(ChestScriptableObject _chestScriptableObject)
        {
            this.chestScriptableObject = _chestScriptableObject;
            chestModel.ResetChestData(_chestScriptableObject);
            chestView.SetChestController(this);
            chestView.EnableChest(chestScriptableObject.chestSprite);
            Debug.Log($"Chest enabled with sprite: {chestScriptableObject.chestSprite}");
        }

        public void Disable()
        {
            chestView.DisableChest();
        }

        public void OnChestSelected()
        {
            int timeToUnlock = (int)(chestModel.timeUnlockInSeconds / 60);
        }

        public void OnChestSelected(float remainingTimeToUnlock)
        {
            int gems = (int)(remainingTimeToUnlock / 60);
        }

        public void OnChestCollected()
        {
            int gemsToAdd = chestModel.GetRandomGems();
            int coinsToAdd = chestModel.GetRandomCoins();
        }

        public float GetUnlockTime()
        {
            return chestModel.timeUnlockInSeconds;
        }

        public void OnChestUnlocked()
        {
            
        }
    }
}
