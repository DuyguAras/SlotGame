using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGames.GameName
{
    public class CombinationManager : MonoBehaviour
    {
        [SerializeField] private List<CombinationSO> combinationSO;

        private List<bool> combinationIndex1 = new List<bool>(); 
        private List<bool> combinationIndex2 = new List<bool>(); 
        private List<bool> combinationIndex3 = new List<bool>(); 

        void Start()
        {
            MatchSameList();
        }

        void Update()
        {
        
        }

        private void MatchSameList()
        {
            /*if (combinationIndex1.Count > 0)
            {
                combinationIndex1.Clear();
                combinationIndex2.Clear();
                combinationIndex3.Clear();
            }*/

            //Create List
            for (int i = 0; i < 5; i++)
            {
                combinationIndex1.Add(combinationSO[0].boolRows[0].bools[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                combinationIndex2.Add(combinationSO[0].boolRows[1].bools[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                combinationIndex3.Add(combinationSO[0].boolRows[2].bools[i]);
            }

            //PRINT
            foreach (var combination in combinationIndex1)
            {
                Debug.Log($"combination {combination}");
            }
            
            foreach (var combination in combinationIndex2)
            {
                Debug.Log($"combination {combination}");
            }
            
            foreach (var combination in combinationIndex3)
            {
                Debug.Log($"combination {combination}");
            }
        }
    }
}
