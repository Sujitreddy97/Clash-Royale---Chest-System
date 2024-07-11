using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem
{
    public class GameResoursesService : GenericSingleton<GameResoursesService>
    {
        public int Coins { get; private set; }
        public int Gems { get; private set; }

        private void Start()
        {
            AddCoins(1000);
            AddGems(100);
        }

        public void AddGems(int gems)
        {
            Gems += gems;
            CallGemsChangedEvent();
        }

        public bool UseGems(int gems)
        {
            if(Gems >= gems)
            {
                Gems -= gems;
                CallGemsChangedEvent();
                return true;
            }
            EventService.Instance.OnNotEnoughResoursesEvent.InvokeEvent();
            return false;
        }

        public void AddCoins(int coins)
        {
            Coins += coins;
            CallCoinsChangedEvent();
        }

        public bool UseCoins(int coins)
        {
            if(Coins >= coins)
            {
                Coins -= coins;
                CallCoinsChangedEvent();
                return true;
            }
            EventService.Instance.OnNotEnoughResoursesEvent.InvokeEvent();
            return false;
        }

        private void CallGemsChangedEvent()
        {
            EventService.Instance.OnGemsChangedEvent.InvokeEvent(Gems);
        }

        private void CallCoinsChangedEvent()
        {
            EventService.Instance.OnCoinsChangedEvent.InvokeEvent(Coins);
        }
    }
}
