using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private bool ePressed = false;
    private bool canTransition = false;

    private Collider2D currentCollision;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(canTransition && currentCollision != null)
            {
                currentCollision.GetComponent<RoomTransition>().PlayTransition();
            }
        }
        if(Input.GetKeyDown(KeyCode.E) && TomarObjet)
        {
            ePressed = true;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Trigger: " + collision.tag);

        if (collision.CompareTag("Transition"))
        {
            Debug.Log("Trigger on: " + collision.name);

            currentCollision = collision;

            canTransition = true;

        }
        if (collision.gameObject.tag == "Item")
        {
            TomarObjet = true;
            if (TomarObjet && ePressed)
            {
                Debug.Log("E pressed.");
                Destroy(collision.gameObject);
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
        if(collision.CompareTag("Item"))
        {
            TomarObjet = false;
        }
    }
}
