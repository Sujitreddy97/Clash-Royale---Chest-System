using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem
{
    public class ChestStateMachineBehaviour : MonoBehaviour
    {
        [SerializeField] private Button chestButton;
        [SerializeField] private TextMeshProUGUI chestStateText;
        [SerializeField] private TextMeshProUGUI chestTimerText;

        private ChestBaseState currentChestState = null;

        public void ChangeChestState(ChestStates chestState, ChestController chestController)
        {
            if (currentChestState != null)
            {
                currentChestState.OnExitState();
                currentChestState = null;
            }

            switch (chestState)
            {
                case ChestStates.Locked:
                    currentChestState = new ChestLockedState(chestStateText, chestButton, chestController);
                    break;
                
                case ChestStates.Unlocking:
                    currentChestState = new ChestUnlockingState(chestController, chestTimerText, chestStateText, 1, chestButton);
                    break;
                case ChestStates.Unlocked:
                    currentChestState = new ChestUnlockedState(chestButton, chestController, chestStateText);
                    break;
                case ChestStates.Collected:
                    currentChestState = new ChestCollectedState(chestController, chestStateText);
                    break;
            }
            currentChestState?.OnEnterState();
        }

        private void Update()
        {
            currentChestState?.Update();
        }
    }
}
