using UnityEngine;

public class MoneyController : MonoBehaviour
{
    private static int amount;
    public static void AddCoins()
    {
        amount++;
        PlayerPrefs.SetInt("Coins", amount);
    }

    public static void AddCoins(int sumToAdd)
    {
        amount += sumToAdd;
        PlayerPrefs.SetInt("Coins", amount);
    }

    public static void SubstractCoins(int sumToSubstract)
    {
        amount -= sumToSubstract;
        PlayerPrefs.SetInt("Coins", amount);
    }
}
