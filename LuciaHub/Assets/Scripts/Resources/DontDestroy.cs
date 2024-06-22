using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Lista de objetos a preservar
    [SerializeField]
    private GameObject[] objectsToPreserve;

    private void Awake()
    {
        foreach (GameObject obj in objectsToPreserve)
        {
            GameObject[] objectsOnScene = GameObject.FindGameObjectsWithTag(obj.tag);

            foreach (GameObject foundObj in objectsOnScene)
            {
                if (foundObj != obj && foundObj.name == obj.name)
                {
                    Destroy(foundObj);
                }
            }

            DontDestroyOnLoad(obj);
        }
    }
}
