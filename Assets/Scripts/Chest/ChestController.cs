
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
            EventService.Instance.OnUnlockChestPressedEvent.AddListener(OnUnlockChestPressed);
            EventService.Instance.OnUnlockImmidiatelyPressedEvent.AddListener(OnUnlockImmidiatePressed);
        }

        public void Disable()
        {
            EventService.Instance.OnUnlockChestPressedEvent.RemoveListener(OnUnlockChestPressed);
            EventService.Instance.OnUnlockImmidiatelyPressedEvent.RemoveListener(OnUnlockImmidiatePressed);
            chestView.DisableChest();
        }

        public void ChangeState(ChestStates newState)
        {
            chestView.ChangeChestState(newState);
        }

        public void OnChestSelected()
        {
            int timeToUnlock = (int)(chestModel.timeUnlockInSeconds / 60);
            EventService.Instance.OnChestSelectedEvent.InvokeEvent(timeToUnlock, this);
        }

        public void OnChestSelected(float remainingTimeToUnlock)
        {
            int gems = (int)(remainingTimeToUnlock / 60);
            EventService.Instance.OnChestSelectedEvent.InvokeEvent(gems, this);
        }

        public void OnChestUnlocked()
        {
            QueueChestService.Instance.DequeChest();
            ChangeState(ChestStates.Unlocked);
        }

        public void OnUnlockChestPressed(ChestController chestController)
        {
            if (chestController != this)
            {
                return;
            }
            QueueChestService.Instance.EnqueChest(this);
        }

        public void OnUnlockImmidiatePressed(int numOfGemsToUse, ChestController chestController)
        {
            if (chestController != this)
            {
                return;
            }

            if (!GameResoursesService.Instance.UseGems(numOfGemsToUse))
            {
                return;
            }

            if(!QueueChestService.Instance.DequeChest(this))
            {
                ChangeState(ChestStates.Unlocked);
            }
        }

        public void OnChestCollected()
        {
            int gemsToAdd = chestModel.GetRandomGems();
            int coinsToAdd = chestModel.GetRandomCoins();
            GameResoursesService.Instance.AddGems(gemsToAdd);
            GameResoursesService.Instance.AddCoins(coinsToAdd);

            ChangeState(ChestStates.Collected);
        }

        public float GetUnlockTime()
        {
            return chestModel.timeUnlockInSeconds;
        }
    }
}
