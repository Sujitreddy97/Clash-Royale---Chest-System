using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem
{
    public class GameService : GenericSingleton<GameService>
    {
        public ChestService chestService {  get; private set; }
        public QueueChestService queueChestService { get; private set; }
        public GameResoursesService gameResoursesService { get; private set;}
        public PopupPanelUI popupPanelUI { get; private set; }

        [Header("Chest Service")]
        [SerializeField] private ChestView chestView;
        [SerializeField] private Transform parent;
        [SerializeField] private ChestScriptableObjectList chestsList;
        [SerializeField] private int maxNumberOfChest = 3;
        [SerializeField] private int costPerChest = 50;

        [Header("Queue Service")]
        [SerializeField] private int maxNumberOfChestToEnque;

        [Header("Popup Panel UI")]
        [SerializeField] private GameObject popupPanel;
        [SerializeField] private TextMeshProUGUI popupText, unlockImmidiatelyText;
        [SerializeField] private Button unlockButton, unlockImmidiateButton, closePopupButton;

        [SerializeField] private TextMeshProUGUI coinsText, gemsText;

        private void Start()
        {
            CreateServices();
        }

        private void CreateServices()
        {
            chestService = new ChestService(chestView, parent, chestsList, maxNumberOfChest, costPerChest);
            queueChestService = new QueueChestService(maxNumberOfChestToEnque);
            gameResoursesService = new GameResoursesService();
            popupPanelUI = new PopupPanelUI(popupPanel, popupText, unlockImmidiatelyText, unlockButton, unlockImmidiateButton, closePopupButton);
        }

        private void OnEnable()
        {
            EventService.Instance.OnCoinsChangedEvent.AddListener(ChangeCoinsText);
            EventService.Instance.OnGemsChangedEvent.AddListener(ChangeGemsText);
        }
        private void OnDisable()
        {
            EventService.Instance.OnCoinsChangedEvent.RemoveListener(ChangeCoinsText);
            EventService.Instance.OnGemsChangedEvent.RemoveListener(ChangeGemsText);
        }

        void ChangeCoinsText(int value)
        {
            coinsText.text = value.ToString();
        }

        void ChangeGemsText(int value)
        {
            gemsText.text = value.ToString();
        }
    }
}
