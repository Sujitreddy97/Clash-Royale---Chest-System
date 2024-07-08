using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem
{
    [CreateAssetMenu(fileName = "ListOfChests", menuName = "ScriptableObjects/ChestList")]
    public class ChestScriptableObjectList : ScriptableObject
    {
        public List<ChestScriptableObject> chestScriptableList;
    }
}