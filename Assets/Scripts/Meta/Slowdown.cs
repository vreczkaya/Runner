using UnityEngine;
using UnityEngine.UI;

public class Slowdown : MonoBehaviour
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
        ButtonsController.OnMixSlowdown += Mix;
    }
    private bool CheckElements()
    {
        return (Elements.blueElementAmount >= 2 && Elements.greenElementAmount >= 3 && Elements.blackElementAmount >= 2 && MoneyController.amount >= 3500);
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
            Shield.Deselect();
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
        Elements.SubstractElement(Elements.blueElementAmount, 2);
        Elements.SubstractElement(Elements.greenElementAmount, 3);
        Elements.SubstractElement(Elements.blackElementAmount, 2);
        Substract?.Invoke(8500);
    }
}
