using UnityEngine;

public class MainMenuActions : MonoBehaviour
{
    [SerializeField] private string mainScene;

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        GameState.Reset();
        GameState.ChangeScene(mainScene);
    }

    public void RestartGame()
    {
        GameState.LivesCount = GameState.DefaultLives;
        GameState.ChangeScene(GameState.CurrentLevelName);
    }
}
