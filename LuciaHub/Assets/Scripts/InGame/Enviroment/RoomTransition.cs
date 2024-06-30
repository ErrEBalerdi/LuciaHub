using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private Spawns spawnToLoad;

    public void PlayTransition()
    {
        GameManager.Instance.EnterRoom(sceneToLoad,(int)spawnToLoad);
    }
}
