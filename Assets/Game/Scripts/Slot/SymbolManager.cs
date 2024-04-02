using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGames.GameName
{
    public class SymbolManager : MonoBehaviour
    {
        [SerializeField] private int verticalHeight;
        [SerializeField] private int horizontalHeight;
        [SerializeField] private float horizontalSpacing;
        [SerializeField] private float verticalSpacing;
        private int order;

        [SerializeField] private List<GameObject> symbols;
        private List<GameObject> symbolsHolder = new();

        [HideInInspector] public GameObject firstSymbol, secondSymbol;

        public void Slots()
        {
            DestroyPreviousList();

            for (int x = 0; x < horizontalHeight; x++)
            {
                for (int y = 0; y < verticalHeight; y++)
                {
                    Vector2 spacing = new Vector2(x * horizontalSpacing, y * verticalSpacing);

                    GameObject symbol = Instantiate(symbols[Random.Range(0, symbols.Count)], spacing, Quaternion.identity);
                    symbolsHolder.Add(symbol);
                    order++;
                    symbol.GetComponent<SymbolCombinationManager>().symbolOrder = order;
                }
            }

            Invoke(nameof(CombinationCheck), 2f);
        }

        private void DestroyPreviousList()
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

        public void CombinationCheck()
        {
            foreach (var AllSymbols in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (AllSymbols.name == "Symbol_1(Clone)" || AllSymbols.name == "Symbol_2(Clone)" || AllSymbols.name == "Symbol_3(Clone)" || AllSymbols.name == "Symbol_4(Clone)" || AllSymbols.name == "Symbol_5(Clone)" || AllSymbols.name == "Symbol_6(Clone)" || AllSymbols.name == "Symbol_7(Clone)" || AllSymbols.name == "Symbol_8(Clone)")
                {
                    AllSymbols.GetComponent<SymbolCombinationManager>().SymbolControl();
                }
            }

            Debug.Log($"Combination Check");
        }
    }
}
