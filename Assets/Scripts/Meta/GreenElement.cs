using UnityEngine;

public class GreenElement : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Elements.AddElement(Elements.greenElementAmount, 1);
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("Green", Elements.greenElementAmount);
        }
    }
}