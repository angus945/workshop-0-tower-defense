using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUISystem : MonoBehaviour
{

    [SerializeField] GameObject title;
    [SerializeField] GameObject play;
    [SerializeField] GameObject death;
    [SerializeField] GameObject option;

    void Awake()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.onStateChange += ChangeStateUI;
    }

    void ChangeStateUI(GameManager.GameState last, GameManager.GameState current)
    {
        switch (current)
        {
            case GameManager.GameState.Title:
                title.SetActive(true);
                play.SetActive(false);
                death.SetActive(false);
                option.SetActive(false);
                break;

            case GameManager.GameState.Playing:
                title.SetActive(false);
                play.SetActive(true);
                death.SetActive(false);
                option.SetActive(false);
                break;

            case GameManager.GameState.Death:
                title.SetActive(false);
                play.SetActive(false);
                death.SetActive(true);
                option.SetActive(false);
                break;

            case GameManager.GameState.Option:
                option.SetActive(true);
                break;
        }

    }
}
