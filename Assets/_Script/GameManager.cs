using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Title,
        Playing,
        Death,
        Option,
    }

    static GameState lastState;
    static GameState currentState;

    public Action<GameState, GameState> onStateChange;

    void Start()
    {
        SetState(currentState);
    }
    public void SetState(int state)
    {
        SetState((GameState)state);
    }
    public void SetState(GameState state)
    {
        lastState = currentState;
        currentState = state;

        switch (currentState)
        {
            case GameState.Title:
            case GameState.Option:
                Time.timeScale = 0;
                break;

            case GameState.Playing:
            case GameState.Death:
                Time.timeScale = 1;
                break;
        }

        onStateChange?.Invoke(lastState, currentState);
    }

    public void Reload(GameState state)
    {
        currentState = state;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetPause()
    {
        if (currentState != GameState.Option) SetState(GameState.Option);
        else SetState(lastState);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
