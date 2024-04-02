using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGames.GameName
{
    public class SymbolCombinationManager : MonoBehaviour
    {
        private GameObject slotSymbols;

        [SerializeField] private int symbolID;
        [SerializeField] private List<GameObject> distinguishAllSymbols;
        [SerializeField] private List<GameObject> closeSymbols;
        public int symbolOrder;

        private void Awake()
        {
            slotSymbols = GameObject.Find("Slot_Symbols");
        }

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

            for (int i = 0; i < distinguishAllSymbols.Count; i++)
            {
                float x = Mathf.Abs(this.transform.position.x - distinguishAllSymbols[i].transform.position.x);
                float y = Mathf.Abs(this.transform.position.y - distinguishAllSymbols[i].transform.position.y);

                if (x > 0 && this.symbolID == distinguishAllSymbols[i].GetComponent<SymbolCombinationManager>().symbolID)
                {
                    if (y == 0)
                    {
                        closeSymbols.Add(distinguishAllSymbols[i]);
                    }
                }

                if (y > 0 && this.symbolID == distinguishAllSymbols[i].GetComponent<SymbolCombinationManager>().symbolID)
                {
                    if (x == 0)
                    {
                        closeSymbols.Add(distinguishAllSymbols[i]);
                    }
                }
            }

            if (closeSymbols.Count >= 2)
            {
                foreach (GameObject item in closeSymbols)
                {
                    Destroy(item);
                }

                Destroy(this.gameObject);
            }
            else
            {
                closeSymbols.Clear();
                distinguishAllSymbols.Clear();
            }
        }

        private void OnMouseDown()
        {
            if (slotSymbols.GetComponent<SymbolManager>().firstSymbol == null)
            {
                slotSymbols.GetComponent<SymbolManager>().firstSymbol = this.gameObject;
            }
            else
            {
                slotSymbols.GetComponent<SymbolManager>().secondSymbol = this.gameObject;
                slotSymbols.GetComponent<SymbolManager>().Combination();
            }
        }
    }
}
