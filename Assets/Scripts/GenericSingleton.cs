﻿using System.Collections;
using UnityEngine;

namespace ChestSystem
{
    public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
            }
            else
            {
                Destroy(gameObject);    
            }
        }

    }
}