using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartController : MonoBehaviour
{
    public UIController levelMenuPlane;
    public UIController pauseButton;
    public UIController losePanel;
    public UIController potionsPanel;
    public Button shield;
    public Button slowdown;
    public UIController settingsPanel;

    private PlayerAnimationController playerAnimation;
    public static bool IsGameStarted { get; private set; }

    private void Start()
    {
        losePanel.ShowUIElement(false);
        levelMenuPlane.ShowUIElement(false);
        playerAnimation = FindObjectOfType<PlayerAnimationController>();
        Time.timeScale = 1;
        IsGameStarted = true;
        playerAnimation.TurnToRun();
        pauseButton.ShowUIElement();
        potionsPanel.ShowUIElement();
        settingsPanel.ShowUIElement(false);
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
        potionsPanel.ShowUIElement(false);
        IsGameStarted = false;
    }

    public void BackFromLevelMenu()
    {
        Time.timeScale = 1;
        levelMenuPlane.ShowUIElement(false);
        potionsPanel.ShowUIElement();
        IsGameStarted = true;
    }

    public void StartGame()
    {
        
    }

    public void FinishGame()
    {
        playerAnimation.TurnToIdle();
        IsGameStarted = false;
        Time.timeScale = 0;
        losePanel.ShowUIElement();
    }
    public void SetSettings()
    {
        Time.timeScale = 0;
        settingsPanel.ShowUIElement();
    }

    public void BackFromSettings()
    {
        settingsPanel.ShowUIElement(false);
        Time.timeScale = 1;
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
        RestartPlayerController.isShieldOn = false;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Restart Level", LoadSceneMode.Single);
    }
}
