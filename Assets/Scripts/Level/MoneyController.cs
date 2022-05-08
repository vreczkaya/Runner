using System;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public static int amount;
    public Text coinsText;
    

    private void Start()
    {
        Shield.Substract += SubstractCoins;
        Slowdown.Substract += SubstractCoins;
        ButtonsController.OnBuying += SubstractCoins;
    }

    public void AddCoins()
    {
        amount++;
        PlayerPrefs.SetInt("Coins", amount);
        coinsText.text = "Coins " + amount.ToString();
    }

    public void AddCoins(int sumToAdd)
    {
        amount += sumToAdd;
        PlayerPrefs.SetInt("Coins", amount);
        coinsText.text = "Coins " + amount.ToString();
    }

    public void SubstractCoins(int sumToSubstract)
    {
        amount -= sumToSubstract;
        PlayerPrefs.SetInt("Coins", amount);
        coinsText.text = "Coins " + amount.ToString();
    }
}
