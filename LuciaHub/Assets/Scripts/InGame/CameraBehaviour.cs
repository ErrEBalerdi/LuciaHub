using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float offset;

    private float minX = -3f;
    private float maxX = 3f;
    private PlayerMovement playerDirection;

    void Start()
    {
        playerDirection = target.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Sit�a la camara un poco a la izquierda o a la derecha del personaje segun donde mire

        // ******** Funciona muy brusco, hay que mejorarlo ********

        if (!playerDirection.isFacingRight && offset > 0) offset *= -1;
        if(playerDirection.isFacingRight && offset < 0) offset *= -1;

        // Almacena el valor de donde debe estar la camara cuando se mueve el jugador
        Vector3 desiredPosition = new Vector3(target.transform.position.x + offset, transform.position.y, transform.position.z);

        // Limita el avance de la camara para no salirse del fondo
        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        desiredPosition = new Vector3(clampedX, desiredPosition.y, desiredPosition.z);

        transform.position = desiredPosition;
    }
}
