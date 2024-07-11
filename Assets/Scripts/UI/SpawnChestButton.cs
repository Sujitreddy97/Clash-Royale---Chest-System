using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem
{
    public class SpawnChestButton : MonoBehaviour
    {
        [SerializeField] private Button spawnButton;

        private void Start()
        {
            spawnButton.onClick.AddListener(SpwanButtonPressed);
        }

        public void SpwanButtonPressed()
        {
           GameService.Instance.chestService.GetChestController();
        }
    }
}
