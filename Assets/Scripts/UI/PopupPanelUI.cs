using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem
{
    public class PopupPanelUI
    {
        private GameObject popupPanel;
        private TextMeshProUGUI popupText, unlockImmidiatelyText;
        private Button unlockButton, unlockImmidiateButton, closePopupButton;

        private int requiredGemsToUnlock = 0;

        private ChestController selectedChestController;

        public PopupPanelUI(GameObject _popupPanel, TextMeshProUGUI _popupText, TextMeshProUGUI _unlockImmidiatelyText, Button _unlockButton, Button _unlockImmidiateButton, Button _closePopupButton)
        {
            this.popupPanel = _popupPanel;
            this.popupText = _popupText;
            this.unlockImmidiatelyText = _unlockImmidiatelyText;
            this.unlockButton = _unlockButton;
            this.unlockImmidiateButton = _unlockImmidiateButton;
            this.closePopupButton = _closePopupButton;
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
            popupText.text = "ALL SLOTS ARE OCCUPIED";
            DeactivateBottomPopup();
            popupPanel.SetActive(true);
        }

        public void OnNotEnoughResoursesTriggered()
        {
            popupText.text = "NOT ENOUGH RESOURSES";
            DeactivateBottomPopup();
            popupPanel.SetActive(true);
        }

        public void OnQueueFilledTriggered()
        {
            popupText.text = "QUEUE IS FULL";
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
            popupText.text = "START UNLOCKING CHEST";
            unlockButton.gameObject.SetActive(true);
            unlockImmidiateButton.gameObject.SetActive(true);

            requiredGemsToUnlock = (remainingTimeToUnlockInMinutes + 1) * 3;
            unlockImmidiatelyText.text = "UNLOCK " + requiredGemsToUnlock + " GEMS";
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
