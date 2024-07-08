
using System;
using UnityEngine;

namespace ChestSystem
{
    public class ChestController
    {
        private ChestModel chestModel;
        private ChestView chestView;
        private ChestScriptableObject chestScriptableObject;

        public ChestController(ChestScriptableObject _chestScriptableObject, ChestView _chestView, Transform parent)
        {
            this.chestModel = new ChestModel(this, _chestScriptableObject);
            this.chestView = GameObject.Instantiate<ChestView>(_chestView, parent);
            chestView.SetChestController(this);
            this.chestScriptableObject = _chestScriptableObject;
        }

        public void Enable(ChestScriptableObject _chestScriptableObject)
        {
            this.chestScriptableObject = _chestScriptableObject;
            chestModel.ResetChestData(_chestScriptableObject);
            chestView.SetChestController(this);
            chestView.EnableChest(chestScriptableObject.chestSprite);
        }

        public void Disable()
        {
            chestView.DisableChest();
        }
    }
}
