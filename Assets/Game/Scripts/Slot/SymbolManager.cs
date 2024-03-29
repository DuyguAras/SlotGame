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

        [SerializeField] private List<GameObject> symbols;

        [HideInInspector] public GameObject firstSymbol, secondSymbol;

        void Start()
        {
            Slots();
        }

        
        void Update()
        {
        
        }

        private void Slots()
        {
            for (int x = 0; x < horizontalHeight; x++)
            {
                for (int y = 0; y < verticalHeight; y++)
                {
                    Vector2 spacing = new Vector2(x * horizontalSpacing, y * verticalSpacing);

                    GameObject symbol = Instantiate(symbols[Random.Range(0, symbols.Count)], spacing, Quaternion.identity);
                }
            }
        }

        public void Combination()
        {
            float combinationDistance = Mathf.Abs(firstSymbol.transform.position.x - secondSymbol.transform.position.x);

            if (combinationDistance <= 2)
            {
                Vector2 firstCombination = firstSymbol.transform.position;
                Vector2 secondCombination = secondSymbol.transform.position;

                firstSymbol.transform.position = secondCombination;
                secondSymbol.transform.position = firstCombination;
            }
            else
            {
                Debug.Log("Too Far To Switch");
            }
          
            firstSymbol = null;
            secondSymbol = null;

            Debug.Log("Clicked 2 Symbols");
        }
    }
}
