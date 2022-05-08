using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public static bool IsSelected { get; private set; }
    private static Toggle toggle;
    private static Outline outline;
    public delegate void OnSubstractCoin(int sum);
    public static event OnSubstractCoin Substract;
    private void Start()
    {
        toggle = GetComponent<Toggle>();
        outline = GetComponentInChildren<Outline>();
        outline.effectColor = Color.black;
        ButtonsController.OnMixShield += Mix;
    }
    private bool CheckElements()
    {
        return (Elements.blueElementAmount >= 5 && Elements.yellowElementAmount >= 2 && Elements.whiteElementAmount >= 3 && PlayerPrefs.GetInt("Coins") >= 8500);
    }
    
    private void Update()
    {
        toggle.interactable = CheckElements();
    }

    public void SelectComponent()
    {
        IsSelected = toggle.isOn;
        if (IsSelected)
        {
            Slowdown.Deselect();
            outline.effectColor = Color.cyan;
        }
        else
        {
            outline.effectColor = Color.black;
        }
    }
    public static void Deselect()
    {
        IsSelected = toggle.isOn = false;
        outline.effectColor = Color.black;
    }

    private void Mix()
    {
        Elements.SubstractElement(Elements.blueElementAmount, 5);
        Elements.SubstractElement(Elements.yellowElementAmount, 2);
        Elements.SubstractElement(Elements.whiteElementAmount, 3);
        Substract?.Invoke(8500);
    }
}
