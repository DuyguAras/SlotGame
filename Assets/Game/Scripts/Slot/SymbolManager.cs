using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGames.GameName
{
    public class SymbolManager : MonoBehaviour
    {
        [SerializeField] private int verticalHeight;
        [SerializeField] private int horizontalHeight;

        [SerializeField] private List<GameObject> symbols;

        void Start()
        {
            CreateSlots();
        }

        
        void Update()
        {
        
        }

        private void CreateSlots()
        {
            for (int x = 0; x < horizontalHeight; x++)
            {
                for (int y = 0; y < verticalHeight; y++)
                {
                    GameObject symbol = Instantiate(symbols[Random.Range(0, symbols.Count)], new Vector2(x, y), Quaternion.identity);
                }
            }
        }
    }
}
