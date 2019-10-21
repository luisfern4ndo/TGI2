using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelM3 : MonoBehaviour
{
    public GameObject painelM3;
    public bool colidPlayer;
    public bool painelM3Ativo;
    public string texto;
    public TMP_InputField textoinput;
    public GameObject Smute;
    public GameObject CanvasPauseRestart;
    public GameObject Player;


    public Text aperteX;


    void Start()
    {
        aperteX.enabled = false;
        
    }


    public void Update()
    {
        texto = textoinput.text;

        if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM3Ativo)
        {
            ativarP3();
            aperteX.enabled = false;

        }


        if (Input.GetKeyDown(KeyCode.KeypadEnter) && painelM3Ativo)
        {
            ativarPlataforma();
            P3Continuar();

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


    public void ativarP3()
    {
        painelM3.SetActive(true);
        painelM3Ativo = true;
        Smute.GetComponent<mute>().m3 = false;
        CanvasPauseRestart.GetComponent<Pause>().m3 = false;
        CanvasPauseRestart.GetComponent<Restart>().m3 = false;
        Player.GetComponent<Player>().m3 = false;
        GameObject.Find("InputMoveBool").GetComponent<TMP_InputField>().Select();

    }
    public void P3Continuar()
    {
        painelM3.SetActive(false);
        painelM3Ativo = false;
        Smute.GetComponent<mute>().m3 = true;
        CanvasPauseRestart.GetComponent<Pause>().m3 = true;
        CanvasPauseRestart.GetComponent<Restart>().m3 = true;
        Player.GetComponent<Player>().m3 = true;

    }

    
    public void ativarPlataforma()
    {
        if (texto == "True") {
            AtivarMoveP.ativar = true;
        }
        else
        {
            AtivarMoveP.ativar = false;
        }
    }


}
