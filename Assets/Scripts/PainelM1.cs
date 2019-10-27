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
    public string nomePlayer;

    public Text aperteX;
    public GameObject Smute;
    public GameObject CanvasPauseRestart;
    public GameObject Player;
    public bool botaoAtivo;

    public GameObject ConsoleNomePlayer;
    public GameObject ConsoleInformativo;
    public bool LaserDestruido;


    void Start()
    {
        aperteX.enabled = false;
        //runButton = GameObject.FindGameObjectWithTag("runMonitor1");
        runButton.SetActive(false);
        botaoAtivo = false;
        LaserDestruido = false;

    }


    public void Update()
    {
            nomePlayer = textoInput.text;
           if (nomePlayer.Length > 0)
            {
                runButton.SetActive(true);
            botaoAtivo = true;
           
        }
        else
        {
            runButton.SetActive(false);
            botaoAtivo = false;
        }
        
            if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM1Ativo)
            {
                ativarP1();
                aperteX.enabled = false;
               

        }


            if (Input.GetKeyDown(KeyCode.KeypadEnter) && painelM1Ativo && botaoAtivo)
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
        GameObject.Find("nomeHacker").GetComponent<TMP_InputField>().Select();

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
        ConsoleNomePlayer.GetComponent<TMP_Text>().text = "(" + nomePlayer + ")";
        ConsoleNomePlayer.SetActive(true);
        if (!LaserDestruido)
        {
            Destroy(objectToDestroy);
            LaserDestruido = true;
            ConsoleInformativo.GetComponent<TextMeshProUGUI>().text = "O laser foi desativado!";
            ConsoleInformativo.SetActive(true);
        }

    }



}
