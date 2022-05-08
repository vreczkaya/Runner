using UnityEngine;
using System.Collections;
using System;

public class Coin : MonoBehaviour
{
    MoneyController moneyController;
    SoundsController soundsController;

    private void Start()
    {
        soundsController = FindObjectOfType<SoundsController>();
        moneyController = FindObjectOfType<MoneyController>(); 
    }
    private void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundsController.OnCoinHit?.Invoke();
            moneyController.AddCoins();
            Destroy(this.gameObject);
        }
    }
}
