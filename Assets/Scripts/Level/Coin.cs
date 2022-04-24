using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoneyController.AddCoins();
            Destroy(this.gameObject);
        }
    }
}
