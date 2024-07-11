using TMPro;
using UnityEngine;

namespace ChestSystem
{
    public class GameResoursesUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsText, gemsText;

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
