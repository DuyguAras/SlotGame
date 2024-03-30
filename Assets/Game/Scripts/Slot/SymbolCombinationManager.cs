using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGames.GameName
{
    public class SymbolCombinationManager : MonoBehaviour
    {
        private GameObject slotSymbols;

        [SerializeField] private int SymbolID;
        [SerializeField] private List<GameObject> DistinguishAllSymbols;
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
                        DistinguishAllSymbols.Add(AllSymbols);
                    }
                    
                }
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
