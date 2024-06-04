using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Patron Singleton, permite una sola instancia de este objeto. Si hay otra, este se destruye.
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void LoadGame()
    {
        SceneManager.LoadScene(0);
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
