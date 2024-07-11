using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem
{
    public class QueueChestService
    {
        private int maxNumberOfChestToEnque;
        private List<ChestController> unlockingChestsQueue = new List<ChestController>();

        public QueueChestService(int _maxNumberOfChestToEnque) 
        {
            this.maxNumberOfChestToEnque = _maxNumberOfChestToEnque;
        }

        public void EnqueChest(ChestController chestController)
        {
            if (unlockingChestsQueue.Count <= 0)
            {
                unlockingChestsQueue.Add(chestController);
                chestController.ChangeState(ChestStates.Unlocking);
            }
            else if (unlockingChestsQueue.Count < maxNumberOfChestToEnque)
            {
                unlockingChestsQueue.Add(chestController);
            }
            else if(unlockingChestsQueue.Count == maxNumberOfChestToEnque)
            {
                EventService.Instance.OnQueueIsFullEvent.InvokeEvent();
            }
        }

        public void DequeChest()
        {
            ChestController unlockedChest = unlockingChestsQueue[0];
            unlockedChest.ChangeState(ChestStates.Unlocked);
            unlockingChestsQueue.RemoveAt(0);

            UnlockNextChest();
        }

        public bool DequeChest(ChestController chestController)
        {
            ChestController unlockedChest = unlockingChestsQueue.Find(chestObject => chestObject.Equals(chestController));

            if (unlockedChest != null)
            {
                unlockedChest.ChangeState(ChestStates.Unlocked);
                unlockingChestsQueue.Remove(chestController);
                UnlockNextChest();
                return true;
            }

            return false;
        }

        private void UnlockNextChest()
        {
            if (unlockingChestsQueue.Count > 0)
            {
                unlockingChestsQueue[0]?.ChangeState(ChestStates.Unlocking);
            }
        }
    }
}
