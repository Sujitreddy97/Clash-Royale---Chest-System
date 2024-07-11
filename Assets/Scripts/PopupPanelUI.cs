using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem
{
    public class PopupPanelUI : MonoBehaviour
    {
        [SerializeField] private GameObject popupPanel;
        [SerializeField] private TextMeshProUGUI popupText, unlockImmidiatelyText;
        [SerializeField] private Button unlockButton, unlockImmidiateButton, closePopupButton;

        private int requiredGemsToUnlock = 0;

        private ChestController selectedChestController;

        private void Start()
        {
            closePopupButton.onClick.AddListener(ClosePopupPanelPressed);
            EventService.Instance.OnAllSlotsAreFullEvent.AddListener(OnChestSlotsFilled);
            EventService.Instance.OnChestSelectedEvent.AddListener(OnChestSelectedEventTriggered);
            EventService.Instance.OnNotEnoughResoursesEvent.AddListener(OnNotEnoughResoursesTriggered);
            EventService.Instance.OnQueueIsFullEvent.AddListener(OnQueueFilledTriggered);

            unlockButton.onClick.AddListener(OnUnlockButtonPressed);
            unlockImmidiateButton.onClick.AddListener(OnUnlockImmididiateButtonPressed);
        }

        public void OnChestSlotsFilled()
        {
            popupText.text = "All the Slots are Occupied";
            DeactivateBottomPopup();
            popupPanel.SetActive(true);
        }

        public void OnNotEnoughResoursesTriggered()
        {
            popupText.text = "Not Enough Resourses";
            DeactivateBottomPopup();
            popupPanel.SetActive(true);
        }

        public void OnQueueFilledTriggered()
        {
            Debug.Log("On queue full popup panel");
            popupText.text = "Queue is Full";
            DeactivateBottomPopup();
            popupPanel.SetActive(true);
        }

        private void DeactivateBottomPopup()
        {
            unlockButton.gameObject.SetActive(false);
            unlockImmidiateButton.gameObject.SetActive(false);
        }

        public void ClosePopupPanelPressed()
        {
            popupPanel.SetActive(false);
        }

        private void OnDestroy()
        {
            EventService.Instance.OnAllSlotsAreFullEvent.RemoveListener(OnChestSlotsFilled);
            EventService.Instance.OnChestSelectedEvent.RemoveListener(OnChestSelectedEventTriggered);
            EventService.Instance.OnNotEnoughResoursesEvent.RemoveListener(OnNotEnoughResoursesTriggered);
            EventService.Instance.OnQueueIsFullEvent.RemoveListener(OnQueueFilledTriggered);
        }

        public void OnChestSelectedEventTriggered(int remainingTimeToUnlockInMinutes, ChestController chestController)
        {
            popupPanel.SetActive(true);
            popupText.text = "Start Unlocking the Chest";
            unlockButton.gameObject.SetActive(true);
            unlockImmidiateButton.gameObject.SetActive(true);

            requiredGemsToUnlock = (remainingTimeToUnlockInMinutes + 1) * 3;
            unlockImmidiatelyText.text = "Unlock " + requiredGemsToUnlock + " Gems";
            selectedChestController = chestController;
        }

        public void OnUnlockButtonPressed()
        {
            popupPanel.SetActive(false);
            EventService.Instance.OnUnlockChestPressedEvent.InvokeEvent(selectedChestController);
        }

        public void OnUnlockImmididiateButtonPressed()
        {
            popupPanel.SetActive(false);
            EventService.Instance.OnUnlockImmidiatelyPressedEvent.InvokeEvent(requiredGemsToUnlock, selectedChestController);
        }

    }
}
