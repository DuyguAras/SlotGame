using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace CoreGames.GameName
{
    public class SymbolCombinationManager : MonoBehaviour
    {
        [SerializeField] private int symbolID;
        [SerializeField] private List<GameObject> distinguishAllSymbols;
        [SerializeField] private List<GameObject> matchingSymbols;
        public int symbolOrder;

        public void SymbolControl()
        {
            foreach (var AllSymbols in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (AllSymbols.name == "Symbol_1(Clone)" || AllSymbols.name == "Symbol_2(Clone)" || AllSymbols.name == "Symbol_3(Clone)" || AllSymbols.name == "Symbol_4(Clone)" || AllSymbols.name == "Symbol_5(Clone)" || AllSymbols.name == "Symbol_6(Clone)" || AllSymbols.name == "Symbol_7(Clone)" || AllSymbols.name == "Symbol_8(Clone)")
                {
                    if (this.symbolOrder != AllSymbols.GetComponent<SymbolCombinationManager>().symbolOrder)
                    {
                        distinguishAllSymbols.Add(AllSymbols);
                    }
                    
                }
            }

            #region COMBINATION 1

            //COMBINATION 1 | If there are more than a certain number of identical objects

            for (int i = 0; i < distinguishAllSymbols.Count; i++)
            {
                if (symbolID == distinguishAllSymbols[i].GetComponent<SymbolCombinationManager>().symbolID)
                {
                    matchingSymbols.Add(distinguishAllSymbols[i]);
                }
            }

            if (matchingSymbols.Count >= 2)
            {
                foreach (GameObject item in matchingSymbols)
                {
                    MatchingAnimation(item);
                }

                matchingSymbols.Clear();
                Debug.Log("COMBINATION 1");
            }


            #endregion

            #region COMBINATION 2

            //COMBINATION 2 | If five identical objects come together side by side

            /*for (int i = 0; i < distinguishAllSymbols.Count; i++)
            {
                float x = Mathf.Abs(this.transform.position.x - distinguishAllSymbols[i].transform.position.x);
                float y = Mathf.Abs(this.transform.position.y - distinguishAllSymbols[i].transform.position.y);

                if (x > 0 && this.symbolID == distinguishAllSymbols[i].GetComponent<SymbolCombinationManager>().symbolID)
                {
                    if (y == 0)
                    {
                        matchingSymbols.Add(distinguishAllSymbols[i]);
                    }
                }
            }

            if (matchingSymbols.Count == 4)
            {
                foreach (GameObject item in matchingSymbols)
                {
                    ScaleAndDestroy(item);
                }

                matchingSymbols.Clear();
                Debug.Log("COMBINATION 2");
            }*/

            #endregion

            #region COMBINATION 3

            //COMBINATION 3 | If there are three identical objects vertically

            /*for (int i = 0; i < distinguishAllSymbols.Count; i++)
            {
                float x = Mathf.Abs(this.transform.position.x - distinguishAllSymbols[i].transform.position.x);
                float y = Mathf.Abs(this.transform.position.y - distinguishAllSymbols[i].transform.position.y);

                if (y > 0 && this.symbolID == distinguishAllSymbols[i].GetComponent<SymbolCombinationManager>().symbolID)
                {
                    if (x == 0)
                    {
                        matchingSymbols.Add(distinguishAllSymbols[i]);
                    }
                }
            }

            if (matchingSymbols.Count == 2)
            {
                foreach (GameObject item in matchingSymbols)
                {
                    ScaleAndDestroy(item);
                }

                matchingSymbols.Clear();
                Debug.Log("COMBINATION 3");
            }*/

            #endregion
        }

        private void MatchingAnimation(GameObject item)
        {
            Vector3 itemScale = item.transform.localScale;

            Sequence sequence = DOTween.Sequence();

            sequence.Append(item.transform.DOScale(itemScale * 1.5f, 0.25f));
            sequence.Append(item.transform.DOScale(itemScale * 1.25f, 0.25f));
        }
    }
}
