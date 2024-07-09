using TMPro;
using UnityEngine.UI;

namespace ChestSystem
{
    public class ChestLockedState : ChestBaseState
    {
        private TextMeshProUGUI chestStateText;
        private Button chestButton;
        private ChestController chestController;

        public ChestLockedState(TextMeshProUGUI chestStateText, Button chestButton, ChestController chestController)
        {
            this.chestStateText = chestStateText;
            this.chestButton = chestButton;
            this.chestController = chestController;
        }

        public override void OnEnterState()
        {
            chestStateText.text = "LOCKED";
            chestButton.onClick.AddListener(OnChestButtonPressed);
        }

        public override void OnExitState()
        {
            chestButton.onClick.RemoveListener(OnChestButtonPressed);
        }

        public override void Update()
        {
            
        }

        private void OnChestButtonPressed()
        {
            chestController.OnChestSelected();
        }
    }
}
