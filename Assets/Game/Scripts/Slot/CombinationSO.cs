using System.Collections.Generic;
using UnityEngine;

namespace CoreGames.GameName
{
    [CreateAssetMenu(fileName = "Combination", menuName = "Scriptable Objects/Combination")]
    public class CombinationSO : ScriptableObject
    {
        public List<BoolRow> boolRows;

        [System.Serializable]
        public struct BoolRow
        {
            public List<bool> bools;
        }
    }
}
