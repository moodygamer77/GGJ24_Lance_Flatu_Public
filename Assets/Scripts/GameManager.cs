using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton class. Always access via instance, do not use FindObjectOfType!
[RequireComponent(typeof(GameSceneManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameSceneManager gameSceneManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            gameSceneManager = GetComponent<GameSceneManager>();
        }
    }

    public void StartNewGame()
    {
        gameSceneManager.LoadScene(GameSceneManager.Scene.IntroScene);
    }

    public void LoadLevel()
    {
        gameSceneManager.LoadScene(GameSceneManager.Scene.StealthLevel1Scene);
    }

    public void PrintCredits()
    {

    }
}