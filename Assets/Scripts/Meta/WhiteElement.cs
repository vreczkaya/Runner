using UnityEngine;

public class WhiteElement : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Elements.AddElement(Elements.whiteElementAmount, 1);
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("White", Elements.whiteElementAmount);
        }
    }
}