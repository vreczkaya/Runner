using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountController : MonoBehaviour
{
    public Text coins;
    
    public Text shieldBlue;
    public Text shieldBrown;
    public Text shieldWhite;

    public Text slowdownBlue;
    public Text slowdownGreen;
    public Text slowdownBlack;

    void Update()
    {
        shieldBlue.text = PlayerPrefs.GetInt("Blue").ToString() + "/5";
        shieldBrown.text = PlayerPrefs.GetInt("Brown").ToString() + "/2";
        shieldWhite.text = PlayerPrefs.GetInt("White").ToString() + "/3";

        slowdownBlue.text = PlayerPrefs.GetInt("Blue").ToString() + "/2";
        slowdownGreen.text = PlayerPrefs.GetInt("Green").ToString() + "/3";
        slowdownBlack.text = PlayerPrefs.GetInt("Black").ToString() + "/2";

        coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
