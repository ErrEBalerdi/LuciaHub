using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    [SerializeField] private GameObject Dialogo;
    [SerializeField] private GameObject LoadDialog;
    [SerializeField] private GameObject Indicador;
   
    private Animator TransitionDialog;
    bool indicador = false;
    // Start is called before the first frame update
    void Start()
    {
  
       LoadDialog.SetActive(false);
       TransitionDialog = LoadDialog.AddComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (indicador && Input.GetKeyDown(KeyCode.E))
        {
            LoadDialog.SetActive(true);
            LoadDialogo();
         
            Dialogo.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Indicador.SetActive(true);
          indicador=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Indicador.SetActive(false);
        indicador=false;
    }
    public IEnumerable LoadDialogo()
    {
        yield return new WaitForSeconds(5f);
    }
}
