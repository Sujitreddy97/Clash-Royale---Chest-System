using TMPro;
using UnityEngine;

namespace ChestSystem
{
    public class ChestCollectedState : ChestBaseState
    {
        private ChestController chestController;
        private TextMeshProUGUI chestStateText;
        public ChestCollectedState(ChestController chestController, TextMeshProUGUI chesStateText)
        {
            this.chestController = chestController;
            this.chestStateText = chesStateText;
        }

        public override void OnEnterState()
        {
            chestStateText.text = " ";
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
            GameService.Instance.chestService.ReturnChestController(chestController);
        }
    }
}
