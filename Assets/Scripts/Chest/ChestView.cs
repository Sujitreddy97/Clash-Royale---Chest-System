using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem
{
    public class ChestView : MonoBehaviour
    {
        private ChestController chestController;

        [SerializeField] private Image chestImage;
        [SerializeField] private GameObject chestVisual;

        public void SetChestController(ChestController _chestController)
        {
            this.chestController = _chestController;
        }

        public void EnableChest(Sprite sprite)
        {
            this.chestImage.sprite = sprite;
            chestVisual.SetActive(true);
        }
       
        public void DisableChest()
        {
            chestVisual.SetActive(false);
        }
    }
}
