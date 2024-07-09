using UnityEngine;

namespace ChestSystem
{
    public abstract class ChestBaseState
    {
        public abstract void OnEnterState();

        public abstract void Update();

        public abstract void OnExitState();
    }
}