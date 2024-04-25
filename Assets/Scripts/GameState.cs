using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public static class GameState
{
    public static int DefaultLives => 3;
    public static event UnityAction CoinsChanged; 
    public static string CurrentLevelName;
    
    private static int _livesCount;
    private static int _coinsCount;
    private static int _startCoins;

    public static int LivesCount
    {
        get => _livesCount;
        set
        {
            _livesCount = Mathf.Max(0, value);
            CoinsChanged?.Invoke();
            if (_livesCount == 0) SceneManager.LoadScene("Scenes/Menu/GameOver");
        }
    }
    
    public static int CoinsCount
    {
        get => _coinsCount;
        set
        {
            _coinsCount = Mathf.Max(0, value);
            CoinsChanged?.Invoke();
        }
    }

    public static void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        CurrentLevelName = name;
        _startCoins = CoinsCount;
    }

    public static void Reset()
    {
        LivesCount = DefaultLives;
        CoinsCount = _startCoins;
        ChangeScene(CurrentLevelName);
    }
}
