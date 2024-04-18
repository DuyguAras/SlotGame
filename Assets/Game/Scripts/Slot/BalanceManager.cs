using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CoreGames.GameName
{
    public class BalanceManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI balanceText;
        [SerializeField] private float balance;
        [SerializeField] private float decreaseBalance;
        [SerializeField] private float increaseBalance;
        [SerializeField] private Button spinButton;
        [SerializeField] private Button resetButton;
        private float resetBalance;

        private void Start()
        {
            UpdateBalanceText();
            resetButton.interactable = false;
            resetBalance = balance;
        }


        private void UpdateBalanceText()
        { 
            if (balanceText != null)
            {
                balanceText.text = "Balance: " + balance.ToString();
            }
        }

        public void IncreaseBalance()
        {
            balance *= increaseBalance;
            UpdateBalanceText();
        }

        public void DecreaseBalance()
        {
            if (balance >= decreaseBalance)
            {
                balance -= decreaseBalance;
                UpdateBalanceText();
            }
            else
            {
                spinButton.interactable = false;
                resetButton.interactable = true;
            }
        }
        
        public void ResetBalance()
        {
            balance = resetBalance;
            UpdateBalanceText();

            spinButton.interactable = true;
            resetButton.interactable = false;
        }
    }
}
