using TMPro;
using UnityEngine.UI;

namespace ChestSystem
{
    public class ChestUnlockedState : ChestBaseState
    {
        private Button chestButton;
        private ChestController chestController;
        private TextMeshProUGUI chestStateText;

        public ChestUnlockedState(Button checkButton, ChestController chestController, TextMeshProUGUI chestStateText)
        {
            this.chestButton = checkButton;
            this.chestController = chestController; 
            this.chestStateText = chestStateText;
        }

        public override void OnEnterState()
        {
            chestButton.onClick.AddListener(OnChestButtonPressed);
            chestStateText.text = "UNLOCKED";
        }

        public override void OnExitState()
        {
            chestButton.onClick.RemoveListener(OnChestButtonPressed);
            
        }

        public override void Update()
        {
            
        }

        public void OnChestButtonPressed()
        {
            chestController.OnChestCollected();
        }
    }
}
