using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGames.GameName
{
    public class SymbolCombinationManager : MonoBehaviour
    {
        private GameObject slotSymbols;

        private void Awake()
        {
            slotSymbols = GameObject.Find("Slot_Symbols");
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
