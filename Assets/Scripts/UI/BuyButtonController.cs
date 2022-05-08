using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonController : MonoBehaviour
{
    public Button buyBlueElement;
    
    void Update()
    {
        if (MoneyController.amount < 1000)
        {
            buyBlueElement.interactable = false;
        }
        else
        {
            buyBlueElement.interactable = true;
        }
    }
}
