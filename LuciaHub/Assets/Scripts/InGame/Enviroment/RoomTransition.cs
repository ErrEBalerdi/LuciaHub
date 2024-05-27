using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    public void PlayTransition()
    {
        GameManager.Instance.EnterRoom(sceneToLoad);
    }
}
