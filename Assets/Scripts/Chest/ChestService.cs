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

            for (int i = 0; i < maxNumberOfChest; i++)
            {
                SpawnChestController();
            }
        }

        public void SpawnChestController()
        {
            int randomIndex = Random.Range(0, chestsList.chestScriptableList.Count);
            ChestController chestController = new ChestController(chestsList.chestScriptableList[randomIndex], chestView, parent);
            
            ReturnChestController(chestController);
        }

        public void ReturnChestController(ChestController _chestController)
        {
            chestObjectPool.ReturnChestObject(_chestController);
            _chestController.Disable();
        }

        public void GetChestController()
        {
            ChestController chestController = chestObjectPool.GetChest();
            
            if (chestController != null)
            {
                if (GameResoursesService.Instance.UseCoins(costPerChest))
                {
                    int randomIndex = Random.Range(0, chestsList.chestScriptableList.Count);
                    chestController.Enable(chestsList.chestScriptableList[randomIndex]);
                }
                else
                {
                    EventService.Instance.OnNotEnoughResoursesEvent.InvokeEvent();
                }
            }
            else
            {
                EventService.Instance.OnAllSlotsAreFullEvent.InvokeEvent();
            }
        }
    }
}
