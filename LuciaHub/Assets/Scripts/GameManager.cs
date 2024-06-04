using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPositions;
    [SerializeField] private Transform playerTransform;
    private Transform spawnPositionObject;
    // Patron Singleton, permite una sola instancia de este objeto. Si hay otra, este se destruye.
    public static GameManager Instance { get; private set; }
    public float minX;
    public float maxX; 
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    private void Start()
    {
        // Le paso 0 para indicar la primer posición de la lista provisoriamente
        SpawnPlayer(0);
    }

    public void SpawnPlayer(int pos)
    {
        // Inicializar las variables: objeto que contiene las posiciones, accedo al transform
        // Lista de transform la inicializo y luego la relleno con los que tenga el objeto

        spawnPositionObject = GameObject.FindWithTag("SpawnPos").GetComponent<Transform>();
        if (spawnPositionObject == null)
            Debug.LogWarning("Spawn Position Object not found.");
        spawnPositions = new List<Transform>();

        foreach (Transform spawnPoint in spawnPositionObject)
        {
            spawnPositions.Add(spawnPoint);
        }

        // Se asigna el transform.position del spawn al jugador
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        if (playerTransform != null)
            playerTransform.position = spawnPositions[pos].position;
        else
            Debug.LogWarning("Player not Found");

        

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
       
    }
    public void EnterRoom(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        SpawnPlayer(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (currentSceneIndex)
        {
            case 1:
                minX = -10f;
                maxX = 15f;
                break;
          case 2:
                minX = -1.5f;
                maxX = 7f;
                break ;
        }
    }
}
