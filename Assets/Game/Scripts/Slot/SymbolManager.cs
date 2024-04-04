using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGames.GameName
{
    public class SymbolManager : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CombinationManager combinationManager;

        [Header("Grid Settings")]
        [SerializeField] private int verticalHeight;
        [SerializeField] private int horizontalHeight;
        [SerializeField] private float horizontalSpacing;
        [SerializeField] private float verticalSpacing;

        [Header("Symbol")]
        [SerializeField] private List<GameObject> symbols;
        private List<GameObject> symbolsHolder = new();

        //COMBINATIONS
        private List<GameObject> combinationObjects = new();

        public void Spin()
        {
            DestroyPreviousSymbolList();
            CreateSymbols();
            CheckAllCombinations();
        }

        private void DestroyPreviousSymbolList()
        {
            if (symbolsHolder.Count > 0)
            {
                foreach (GameObject symbol in symbolsHolder)
                {
                    Destroy(symbol);
                }

                symbolsHolder.Clear();
            }
        }

        private void CreateSymbols()
        {
            for (int x = 0; x < verticalHeight; x++)
            {
                for (int y = 0; y < horizontalHeight; y++)
                {
                    Vector2 position = new Vector2(y * horizontalSpacing, x * verticalSpacing);

                    GameObject symbol = Instantiate(symbols[Random.Range(0, symbols.Count)], position, Quaternion.identity);
                    symbolsHolder.Add(symbol);
                }
            }
        }

        private void CheckAllCombinations()
        {
            for (int i = 0; i < combinationManager.combinationSO.Count; i++)
            {
                combinationManager.GetSOCombination(i);
                CombinationControl();
            }
        }

        private void CombinationControl()
        {
            List<GameObject> combinationIndex1 = new List<GameObject>();
            List<GameObject> combinationIndex2 = new List<GameObject>();
            List<GameObject> combinationIndex3 = new List<GameObject>();

            if (combinationObjects.Count > 0)
            {
                combinationObjects.Clear();
            }

            //MATCH
            MatchingCombinationIndex(0,5, combinationIndex3);
            MatchingCombinationIndex(5,10, combinationIndex2);
            MatchingCombinationIndex(10,15, combinationIndex1);

            //MATCH
            CorrectCombinations(combinationManager.combinationIndex1, combinationIndex1);
            CorrectCombinations(combinationManager.combinationIndex2, combinationIndex2);
            CorrectCombinations(combinationManager.combinationIndex3, combinationIndex3);

            //CHECK
            SameSymbolID();
        }

        private void MatchingCombinationIndex(int startValue, int finishValue, List<GameObject> combinationIndex)
        {
            for (int i = startValue; i < finishValue; i++)
            {
                combinationIndex.Add(symbolsHolder[i]);
            }
        }

        private void CorrectCombinations(List<bool> combinationIndexManager, List<GameObject> combinationIndex)
        {
            for (int i = 0; i < combinationIndexManager.Count; i++)
            {
                if (combinationIndexManager[i])
                {
                    combinationObjects.Add(combinationIndex[i]);
                }
            }
        }

        private void SameSymbolID()
        {
            if (combinationObjects.Count == 5)
            {
                if (combinationObjects[0].GetComponent<Symbol>().ID == combinationObjects[1].GetComponent<Symbol>().ID &&
                   combinationObjects[0].GetComponent<Symbol>().ID == combinationObjects[2].GetComponent<Symbol>().ID &&
                   combinationObjects[0].GetComponent<Symbol>().ID == combinationObjects[3].GetComponent<Symbol>().ID &&
                    combinationObjects[0].GetComponent<Symbol>().ID == combinationObjects[4].GetComponent<Symbol>().ID)
                {
                    foreach (GameObject item in combinationObjects)
                    {
                        CombinationAnimation(item);
                    }

                    Debug.Log($"Combination Completed");
                }
            }
        }

        private void CombinationAnimation(GameObject item)
        {
            Vector3 itemScale = item.transform.localScale;

            Sequence sequence = DOTween.Sequence();

            sequence.Append(item.transform.DOScale(itemScale * 1.5f, 0.25f));
            sequence.Append(item.transform.DOScale(itemScale * 1.25f, 0.25f));
        }
    }
}
