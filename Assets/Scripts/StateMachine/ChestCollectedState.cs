using UnityEngine;

namespace ChestSystem
{
    public class ChestCollectedState : ChestBaseState
    {
        private ChestController chestController;

        public ChestCollectedState(ChestController chestController)
        {
            this.chestController = chestController;
        }

        public override void OnEnterState()
        {
            ReturnTheChestToPool();
        }

        public override void OnExitState()
        {
           
        }

        public override void Update()
        {
            
        }

        private void ReturnTheChestToPool()
        {
            ChestService.Instance.ReturnChestController(chestController);
        }
    }
}
