using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class ButtonsController : MonoBehaviour
{
    public static int slowdownAmount;
    public static int shieldAmount;
    public UIController settingsPanel;
    public static Action OnMixShield;
    public static Action OnMixSlowdown;
    public delegate void BuySomething(int sum);
    public static event BuySomething OnBuying; 

    private void Start()
    {
        settingsPanel.ShowUIElement(false);
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4744178", false);
        }
    }

    public void MixPotion()
    {
        if (Shield.IsSelected)
        {
            MixShield();
        }
        else if (Slowdown.IsSelected)
        {
            MixSlowdown();
        }
    }
    private void MixShield()
    {
        shieldAmount++;
        PlayerPrefs.SetInt("Shields", shieldAmount);
        OnMixShield?.Invoke();
    }

    private void MixSlowdown()
    {
        slowdownAmount++;
        PlayerPrefs.SetInt("Slowdowns", slowdownAmount);
        OnMixSlowdown?.Invoke();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Level");
    }

    public void OpenSettingsMenu()
    {
        settingsPanel.ShowUIElement();
    }

    public void BackFromSettings()
    {
        settingsPanel.ShowUIElement(false);
    }
    public void BuyBlueElement()
    {
        if (MoneyController.amount >= 1000)
        {
            Elements.AddElement(Elements.blueElementAmount, 1);
            OnBuying?.Invoke(1000);
        }
    } 

    public void WatchAdds()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
        }
    }
}
