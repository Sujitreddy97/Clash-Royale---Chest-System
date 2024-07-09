using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem
{
    public class ChestObjectPool
    {
        class ChestPoolData
        {
            public ChestController chestController;
            public bool isActive;
        }

        private List<ChestPoolData> chestPool;

        public ChestObjectPool()
        {
            chestPool = new List<ChestPoolData>();
        }

        public ChestController GetChest()
        {
            ChestPoolData chestPoolObject = chestPool.Find(chestObject => !chestObject.isActive);

            if (chestPoolObject != null)
            {
                chestPoolObject.isActive = true;
                Debug.Log($"Chest retrieved: {chestPoolObject.chestController}");
                return chestPoolObject.chestController;
            }
            else
            {
                Debug.Log("No inactive chest found.");
                return null;
            }
        }


        public void ReturnChestObject(ChestController _chestController)
        {
            ChestPoolData chestPoolObject = chestPool.Find(chestObject => chestObject.chestController.Equals(_chestController));

            if (chestPoolObject != null)
            {
                chestPoolObject.isActive = false;
            }
            else
            {
                chestPoolObject = new ChestPoolData();
                chestPoolObject.isActive = false;
                chestPoolObject.chestController = _chestController;
                chestPool.Add(chestPoolObject);
            }
        }
    }
}
