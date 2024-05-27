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

    public float smoothTime = 20f;
    private Vector2 velocity = Vector2.zero;

    void Start()
    {
        playerDirection = target.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Sitúa la camara un poco a la izquierda o a la derecha del personaje segun donde mire

        // '?' Es un operador ternario (como un if else)
        // Mathf.Abs saca el valor absoluto. Por lo que si le pones un menos antes, es el mismo valor en negativo.

        offset = playerDirection.isFacingRight ? Mathf.Abs(offset) : -Mathf.Abs(offset);

        // Almacena el valor de donde debe estar la camara cuando se mueve el jugador
        Vector3 desiredPosition = new Vector3(target.transform.position.x + offset, transform.position.y, transform.position.z);

        // Limita el avance de la camara para no salirse del fondo
        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        desiredPosition = new Vector3(clampedX, desiredPosition.y, desiredPosition.z);


        //transform.position = desiredPosition;
        // Esto es el concepto de interpolación. No lo se, la linea la escribio chatpgt xd
        transform.position = Vector2.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}
