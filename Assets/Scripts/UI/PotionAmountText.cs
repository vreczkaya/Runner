using UnityEngine;
using UnityEngine.UI;

public class PotionAmountText : MonoBehaviour
{
    public Text shieldAmount;
    public Text slowdownAmount;
    void Update()
    {
        shieldAmount.text = PlayerPrefs.GetInt("Shields").ToString();
        slowdownAmount.text = PlayerPrefs.GetInt("Slowdowns").ToString();
    }
}
