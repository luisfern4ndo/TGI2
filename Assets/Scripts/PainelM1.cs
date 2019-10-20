using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelM1 : MonoBehaviour
{
    public GameObject painelM1;
    public bool colidPlayer;
    public GameObject objectToDestroy;
    public bool painelM1Ativo;
    public GameObject runButton;
    public TMP_InputField textoInput;
    public string texto;

    public Text aperteX;
    public GameObject Smute;
    public GameObject CanvasPauseRestart;
    public GameObject Player;


    void Start()
    {
        aperteX.enabled = false;
        //runButton = GameObject.FindGameObjectWithTag("runMonitor1");
        runButton.SetActive(false);

    }


    public void Update()
    {
            texto = textoInput.text;
           if (texto.Length > 0)
            {
                runButton.SetActive(true);
        }
        else
        {
            runButton.SetActive(false);
        }
        
            if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM1Ativo)
            {
                ativarP1();
                aperteX.enabled = false;

            }

            else if (!colidPlayer || Input.GetKeyDown(KeyCode.X) && painelM1Ativo)
            {
                P1Continuar();
                
            }


            if (Input.GetKeyDown(KeyCode.KeypadEnter) && painelM1Ativo)
            {
                P1Continuar();
                DestroyGameObject();
            }


    }

        public void OnTriggerEnter2D(Collider2D collision2d)
        {
            if (collision2d.gameObject.CompareTag("Player"))
            {
                colidPlayer = true;
                aperteX.enabled = true;

        }

        }

        public void OnTriggerExit2D(Collider2D collision2d)
        {
        if (collision2d.gameObject.CompareTag("Player"))
        {
            colidPlayer = false;
            aperteX.enabled = false;
        }
        
        }


        public void ativarP1()
        {
            painelM1.SetActive(true);
            painelM1Ativo = true;
        Smute.GetComponent<mute>().m1 = false;
        CanvasPauseRestart.GetComponent<Pause>().m1 = false;
        CanvasPauseRestart.GetComponent<Restart>().m1 = false;
        Player.GetComponent<Player>().m1 = false;

    }
        public void P1Continuar()
        {
            painelM1.SetActive(false);
            painelM1Ativo = false;
        Smute.GetComponent<mute>().m1 = true;
        CanvasPauseRestart.GetComponent<Pause>().m1 = true;
        CanvasPauseRestart.GetComponent<Restart>().m1 = true;
        Player.GetComponent<Player>().m1 = true;

    }

    public void DestroyGameObject()
    {

        Destroy(objectToDestroy);


    }



}
