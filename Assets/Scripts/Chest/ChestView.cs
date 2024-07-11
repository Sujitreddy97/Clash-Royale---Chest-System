using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem
{
    public class ChestView : MonoBehaviour
    {
        private ChestController chestController;

        [SerializeField] private Image chestImage;
        [SerializeField] private GameObject chestVisual;

        [SerializeField] private ChestStateMachineBehaviour chestStateMachine;

        public void SetChestController(ChestController _chestController)
        {
            this.chestController = _chestController;
        }

        public void EnableChest(Sprite sprite)
        {
            chestVisual.SetActive(true);
            this.chestImage.sprite = sprite;
            ChangeChestState(ChestStates.Locked);
        }
       
        public void DisableChest()
        {
            chestVisual.SetActive(false);
        }

        public void ChangeChestState(ChestStates newState)
        {
          chestStateMachine.ChangeChestState(newState, this.chestController);
        }
    }
}
