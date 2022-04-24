using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UIController levelMenuPlane;
    public UIController startButton;
    
    private PlayerAnimationController playerAnimation;
    public static bool IsGameStarted { get; private set; }

    private void Start()
    {
        startButton.ShowUIElement();
        levelMenuPlane.ShowUIElement(false);
        playerAnimation = FindObjectOfType<PlayerAnimationController>();
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
        startButton.ShowUIElement(false);
        playerAnimation.TurnToRun();
        IsGameStarted = true;
    }

    public void FinishGame()
    {
        playerAnimation.TurnToIdle();
        IsGameStarted = false;
    }
}
