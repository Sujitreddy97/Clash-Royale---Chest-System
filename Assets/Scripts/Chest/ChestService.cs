using Assets.Scripts;
using UnityEngine;

namespace ChestSystem
{
    public class ChestService : GenericSingleton<ChestService>
    {
        [SerializeField] private ChestView chestView;
        [SerializeField] private Transform parent;
        [SerializeField] private ChestScriptableObjectList chestsList;
        [SerializeField] private int maxNumberOfChest = 3;
        [SerializeField] private int costPerChest = 50;

        private ChestObjectPool chestObjectPool;

        void Start()
        {
            chestObjectPool = new ChestObjectPool();
            Debug.Log("ChestObjectPool initialized.");

            for (int i = 0; i < maxNumberOfChest; i++)
            {
                SpawnChestController();
            }
        }

        public void SpawnChestController()
        {
            int randomIndex = Random.Range(0, chestsList.chestScriptableList.Count);
            ChestController chestController = new ChestController(chestsList.chestScriptableList[randomIndex], chestView, parent);
            chestObjectPool.ReturnChestObject(chestController); // Add to pool
            Debug.Log($"ChestController spawned and added to pool: {chestController}");
        }

        public void ReturnChestController(ChestController _chestController)
        {
            chestObjectPool.ReturnChestObject(_chestController);
            _chestController.Disable();
            Debug.Log($"ChestController returned to pool: {_chestController}");
        }

        public void GetChestController()
        {
            ChestController chestController = chestObjectPool.GetChest();
            int randomIndex = Random.Range(0, chestsList.chestScriptableList.Count);

            if (chestController != null)
            {
                chestController.Enable(chestsList.chestScriptableList[randomIndex]);
                Debug.Log($"ChestController enabled: {chestController}");
            }
            else
            {
                Debug.Log("Chest controller is null");
            }
        }
    }
}
