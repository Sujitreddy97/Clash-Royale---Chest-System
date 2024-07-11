using UnityEngine;

namespace ChestSystem
{
    public class ChestService
    {
        private ChestView chestView;
        private Transform parent;
        private ChestScriptableObjectList chestsList;
        private int maxNumberOfChest;
        private int costPerChest;

        private ChestObjectPool chestObjectPool;

        public ChestService(ChestView _chestView, Transform _parent, ChestScriptableObjectList _chestList, int _maxNumberOfChest, int _costPerChest)
        {
            this.chestView = _chestView;
            this.parent = _parent;
            this.chestsList = _chestList;
            this.maxNumberOfChest = _maxNumberOfChest;
            this.costPerChest = _costPerChest;

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
                if (GameService.Instance.gameResoursesService.UseCoins(costPerChest))
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
