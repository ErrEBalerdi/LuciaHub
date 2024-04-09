using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMainMenu : MonoBehaviour
{
   
    
    void MenuSpanish()
    {
        TextMeshProUGUI textMeshProJugar = GameObject.Find("TextRunGame").GetComponent<TextMeshProUGUI>();
        textMeshProJugar.text = "JUGAR";
        textMeshProJugar.ForceMeshUpdate();
        TextMeshProUGUI textMeshProOPCIONES = GameObject.Find("TextOptions").GetComponent<TextMeshProUGUI>();
        textMeshProOPCIONES.text = "OPCIONES";
        textMeshProOPCIONES.ForceMeshUpdate();
        TextMeshProUGUI textMeshProSALIR = GameObject.Find("TextQuit").GetComponent<TextMeshProUGUI>();
        textMeshProSALIR.text = "SALIR";
        textMeshProSALIR.ForceMeshUpdate();
    }
    void MenuEnglish()
    {
        TextMeshProUGUI textMeshProJugar = GameObject.Find("TextRunGame").GetComponent<TextMeshProUGUI>();
        textMeshProJugar.text = "PLAY";
        textMeshProJugar.ForceMeshUpdate();
        TextMeshProUGUI textMeshProOPCIONES = GameObject.Find("TextOptions").GetComponent<TextMeshProUGUI>();
        textMeshProOPCIONES.text = "OPTIONS";
        textMeshProOPCIONES.ForceMeshUpdate();
        TextMeshProUGUI textMeshProSALIR = GameObject.Find("TextQuit").GetComponent<TextMeshProUGUI>();
        textMeshProSALIR.text = "QUIT";
        textMeshProSALIR.ForceMeshUpdate();
    }
    // Start is called before the first frame update
    void Start()
    { //Ejecuta el lenguaje del menu prinsipal (realizar un if que pueda camviar el idioma desde el menu de opciones)
        MenuSpanish();
        //MenuEnglish();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
