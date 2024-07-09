using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem
{
    public class ChestUnlockingState : ChestBaseState
    {
        private ChestController chestController;
        private TextMeshProUGUI chestTimerText;
        private int timeIntervalToUpdateText;
        private float timeToUnlock;
        private float currentTime;

        private Button chestButton;

        public ChestUnlockingState(ChestController chestController, TextMeshProUGUI chestTimerText, int timeIntervalToUpdateText, Button chestButton)
        {
            this.chestController = chestController;
            this.chestTimerText = chestTimerText;
            this.timeIntervalToUpdateText = timeIntervalToUpdateText;
            this.timeToUnlock = chestController.GetUnlockTime();
            this.currentTime = timeIntervalToUpdateText;
            this.chestButton = chestButton;
        }

        public override void OnEnterState()
        {
            UpdateTimerText();
            chestButton.onClick.AddListener(OnChestButtonPressed);
        }

        public override void OnExitState()
        {
            chestButton.onClick.RemoveListener(OnChestButtonPressed);
        }

        public override void Update()
        {
            if (timeToUnlock <= 0)
            {
                return;
            }

            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                timeToUnlock -= timeIntervalToUpdateText;
                currentTime = timeIntervalToUpdateText;
                if (timeToUnlock <= 0)
                {
                    timeToUnlock = 0;
                    OnChestUnlocked();
                }
                UpdateTimerText();
            }
        }

        public void UpdateTimerText()
        {
            int minutes = (int)(timeToUnlock / 60);
            int seconds = (int)(timeToUnlock % 60);

            chestTimerText.text = minutes + " : " + seconds;
        }

        public void OnChestUnlocked()
        {
            chestController.OnChestUnlocked();
        }

        public void OnChestButtonPressed()
        {
            chestController.OnChestSelected(timeToUnlock);
        }
    }

}

