using UnityEngine;

public class UIController : MonoBehaviour
{
    public void ShowUIElement(bool show = true)
    {
        gameObject.SetActive(show);
    }
}
