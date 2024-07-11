using TMPro;
using UnityEngine;

namespace ChestSystem
{
    public class GameResoursesUI
    {
        private TextMeshProUGUI coinsText, gemsText;

        public GameResoursesUI(TextMeshProUGUI _coinsText, TextMeshProUGUI _gemsText)
        {
            this.coinsText = _coinsText;
            this.gemsText = _gemsText;
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
