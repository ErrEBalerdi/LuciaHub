using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private bool ePressed = false;
    private bool canTransition = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTransition)
        {
            ePressed = true;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger: " + collision.tag);

        if (collision.CompareTag("Transition"))
        {
            canTransition = true;

            if (canTransition && ePressed)
            {
                Debug.Log("E pressed.");
                collision.GetComponent<RoomTransition>().PlayTransition();
            }
        }
     
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Transition"))
        {
            canTransition = false;
        }
        ePressed = false;
    }
}
