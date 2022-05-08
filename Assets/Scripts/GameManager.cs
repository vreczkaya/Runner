using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public UIController levelMenuPlane;
    public UIController settingsPanel;
    public UIController pauseButton;
    public UIController losePanel;
    public UIController menuPanel;
    public UIController potionsPanel;
    private PlayerAnimationController playerAnimation;
    public Button shield;
    public Button slowdown;
    public static bool IsGameStarted { get; private set; }

    private void Start()
    {
        levelMenuPlane.ShowUIElement(false);
        playerAnimation = FindObjectOfType<PlayerAnimationController>();
        settingsPanel.ShowUIElement(false);
        pauseButton.ShowUIElement(false);
        losePanel.ShowUIElement(false);
        potionsPanel.ShowUIElement(false);
        IsGameStarted = false;
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Shields") == 0)
        {
            shield.interactable = false;
        }
        if (PlayerPrefs.GetInt("Slowdowns") == 0)
        {
            slowdown.interactable = false;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        levelMenuPlane.ShowUIElement();
        IsGameStarted = false;
    }

    public void BackFromLevelMenu()
    {
        Time.timeScale = 1;
        levelMenuPlane.ShowUIElement(false);
        IsGameStarted = true;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        IsGameStarted = true;
        menuPanel.ShowUIElement(false);
        potionsPanel.ShowUIElement();
        
        playerAnimation.TurnToRun();
        pauseButton.ShowUIElement();
    }

    public void FinishGame()
    {
        playerAnimation.TurnToIdle();
        IsGameStarted = false;
        Time.timeScale = 0;
        losePanel.ShowUIElement();
    }

    public void GoToTheShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void GoToTheLab()
    {
        SceneManager.LoadScene("Laboratory");
    }

    public void SetSettings()
    {
        Time.timeScale = 0;
        settingsPanel.ShowUIElement();
        potionsPanel.ShowUIElement(false);
    }

    public void BackFromSettings()
    {
        settingsPanel.ShowUIElement(false);
        Time.timeScale = 1;
        potionsPanel.ShowUIElement();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Restart Level", LoadSceneMode.Single);
    }
    public void SlowdownButton()
    {
        int amount = PlayerPrefs.GetInt("Slowdowns");
        if (amount == 0) 
            return;
        StartCoroutine(Slowdown());
        amount--;
        PlayerPrefs.SetInt("Slowdowns", amount);
    }
    public void ShieldButton()
    {
        int amount = PlayerPrefs.GetInt("Shields");
        if (amount == 0)
            StartCoroutine(TurnOnShield());
        amount--;
        PlayerPrefs.SetInt("Shields", amount);
    }
    private IEnumerator Slowdown()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(40);
        Time.timeScale = 1;
    }
    private IEnumerator TurnOnShield()
    {
        PlayerController.isShieldOn = true;
        yield return new WaitForSeconds(20);
        Debug.Log(PlayerController.isShieldOn);
        PlayerController.isShieldOn = false;
    }
}
