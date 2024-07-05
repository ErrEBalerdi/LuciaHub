using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float offset;
    private float minX;
    private float maxX;
    private float camWidth;

    public float MinX { get; set; }
    public float MaxX { get; set; }

    private PlayerMovement playerDirection;
    public float smoothTime = 20f;
    private Vector2 velocity = Vector2.zero;

    void Start()
    {
        playerDirection = target.GetComponent<PlayerMovement>();

        Camera cam = GetComponent<Camera>();

        float camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        // Guarda todos los objetos con el tag "BackgroundSprite"
        GameObject[] backgroundArray = GameObject.FindGameObjectsWithTag("BackgroundSprite");
        foreach (GameObject background in backgroundArray)
        {
            //Por cada elemento busca el sprite y agarra los valores minimos y maximos
            float backgoundMin = background.GetComponent<SpriteRenderer>().bounds.min.x;
            float backgroundMax = background.GetComponent<SpriteRenderer>().bounds.max.x;

            // Si es el primer elemento, estos seran los minimos y maximos para la camara.
            if(background == backgroundArray[0])
            {
                minX = backgoundMin;
                maxX = backgroundMax;
            }

            // Simplemente guarda el menor en minX y el mayor en maxX
            if (backgoundMin < minX) 
                minX = backgoundMin;

            if(backgroundMax > maxX) 
                maxX = backgroundMax;
        }
    }


    void Update()
    {
     
        // Sitúa la camara un poco a la izquierda o a la derecha del personaje segun donde mire

        // '?' Es un operador ternario (como un if else)
        // Mathf.Abs saca el valor absoluto. Por lo que si le pones un menos antes, es el mismo valor en negativo.

        offset = playerDirection.isFacingRight ? Mathf.Abs(offset) : -Mathf.Abs(offset);

        // Almacena el valor de donde debe estar la camara cuando se mueve el jugador
        Vector2 desiredPosition = new Vector2(target.transform.position.x + offset, transform.position.y);

        // Limita el avance de la camara para no salirse del fondo
        float clampedX = Mathf.Clamp(desiredPosition.x, minX + camWidth /2 , maxX - camWidth /2);
        desiredPosition = new Vector2(clampedX, desiredPosition.y);

        // Esto es el concepto de interpolación. No lo se, la linea la escribio chatpgt xd
        transform.position = Vector2.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}
