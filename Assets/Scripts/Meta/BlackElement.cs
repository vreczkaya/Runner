using UnityEngine;

public class BlackElement : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Elements.AddElement(Elements.blackElementAmount, 1);
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("Black", Elements.blackElementAmount);
        }
    }
}
