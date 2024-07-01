using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem
{
    public class ChestView : MonoBehaviour
    {
        private ChestController chestController;

        [SerializeField] private Image chestImage;
        [SerializeField] private GameObject chestVisual;

        public void SetChestController(ChestController chestController)
        {
            this.chestController = chestController;
        }

        public void EnableChest(Sprite sprite)
        {
            this.chestImage.sprite = sprite;
        }
       
        public void DisableChest()
        {
            chestVisual.SetActive(false);
        }
    }
}
