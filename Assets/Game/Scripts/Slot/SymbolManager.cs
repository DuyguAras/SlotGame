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
            for (int x = 0; x < horizontalHeight; x++)
            {
                for (int y = 0; y < verticalHeight; y++)
                {
                    GameObject symbol = Instantiate(symbols[0], new Vector2(x,y), Quaternion.identity);
                }
            }
        }

        
        void Update()
        {
        
        }
    }
}
