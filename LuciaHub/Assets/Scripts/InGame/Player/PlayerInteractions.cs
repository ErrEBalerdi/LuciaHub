using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private bool keyPressed = false;
    private bool canTransition = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTransition)
        {
            keyPressed = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger: " + collision.tag);

        if (collision.CompareTag("Transition"))
        {
            canTransition = true;

            if (canTransition && keyPressed)
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
        keyPressed = false;
    }
}
