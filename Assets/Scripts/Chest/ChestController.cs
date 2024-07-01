
using UnityEngine;

namespace ChestSystem
{
    public class ChestController
    {
        private ChestModel chestModel;
        private ChestView chestView;

        public ChestController(ChestScriptableObject _chestScriptableObject)
        {
            this.chestModel = new ChestModel(this, _chestScriptableObject);
            this.chestView = GameObject.Instantiate(chestView);
            chestView.SetChestController(this);
        }

        public void Enable(ChestScriptableObject _chestScriptableObject)
        {
            chestModel.ResetChestData(_chestScriptableObject);
            chestView.SetChestController(this);
            chestView.EnableChest(chestModel.GetChestSprite());
        }

        public void Disable()
        {
            chestView.DisableChest();
        }
    }
}
