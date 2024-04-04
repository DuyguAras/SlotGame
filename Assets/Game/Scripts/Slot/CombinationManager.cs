using System.Collections.Generic;
using UnityEngine;

namespace CoreGames.GameName
{
    public class CombinationManager : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private SymbolManager symbolManager;

        [Header("Combination Scriptable Objects")]
        public List<CombinationSO> combinationSO;

        [HideInInspector] public List<bool> combinationIndex1 = new List<bool>();
        [HideInInspector] public List<bool> combinationIndex2 = new List<bool>();
        [HideInInspector] public List<bool> combinationIndex3 = new List<bool>();

        public void GetSOCombination(int combinationSOIndex)
        {
            if (combinationIndex1.Count > 0)
            {
                combinationIndex1.Clear();
                combinationIndex2.Clear();
                combinationIndex3.Clear();
            }

            InitializeCombinationList(combinationIndex1, combinationSOIndex, 0);
            InitializeCombinationList(combinationIndex2, combinationSOIndex, 1);
            InitializeCombinationList(combinationIndex3, combinationSOIndex, 2);
        }

        private void InitializeCombinationList(List<bool> combinationList, int combinationSOIndex, int rowsIndex)
        {
            for (int i = 0; i < 5; i++)
            {
                combinationList.Add(combinationSO[combinationSOIndex].boolRows[rowsIndex].bools[i]);
            }
        }
    }
}
