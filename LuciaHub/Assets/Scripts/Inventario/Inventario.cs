using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<GameObject>inventario = new List<GameObject> ();
    public GameObject invent;
    bool OpenInventario;
    [SerializeField] private GameObject select1;
    [SerializeField] private GameObject select2;
    [SerializeField] private GameObject select3;
    short position;

  
    // Start is called before the first frame update
    void Start()
    {
        OpenInventario = false;
        invent.SetActive(false);
        select1.SetActive(false);
        select2.SetActive(false);
        select3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenInventario = !OpenInventario;
            invent.SetActive(OpenInventario);
            select1.SetActive(OpenInventario);
            if (OpenInventario) 
            {
                position = 1; 
            }else
            {
                select1.SetActive(false);
                select2.SetActive(false);
                select3.SetActive(false);
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && OpenInventario && position != 1)
        {
            select1.SetActive(true);
            select2.SetActive(false);
            select3.SetActive(false);
            position = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && OpenInventario && position != 2)
        {
            select1.SetActive(false);
            select2.SetActive(true);
            select3.SetActive(false);
            position = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && OpenInventario && position != 3)
        {
            select1.SetActive(false);
            select2.SetActive(false);
            select3.SetActive(true);
            position = 3;

        }
       
    }
   
   
    
}

