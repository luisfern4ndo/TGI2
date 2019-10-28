﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PainelM5 : MonoBehaviour
{
    public GameObject painelM5;
    public bool colidPlayer;
    public bool painelM5Ativo;
    public string texto;
    public TMP_InputField textoinput;

    public GameObject Smute;
    public GameObject CanvasPauseRestart;
    public GameObject Player;
    public GameObject Key;

    public Text aperteX;
    public GameObject ConsoleERRO;

    void Start()
    {
        painelM5Ativo = false;
        aperteX.enabled = false;
    }


    void Update()
    {
        texto = textoinput.text;

        if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM5Ativo)
        {
            ativarP5();
            aperteX.enabled = false;

        }


        if (Input.GetKeyDown(KeyCode.KeypadEnter) && painelM5Ativo)
        {
            verificarIndice();
            P5Continuar();

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


    public void ativarP5()
    {
        painelM5.SetActive(true);
        painelM5Ativo = true;
        Smute.GetComponent<mute>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = true;
        Player.GetComponent<Player>().MonitorAtivado = true;
        GameObject.Find("InputIndice").GetComponent<TMP_InputField>().Select();

    }
    public void P5Continuar()
    {
        painelM5.SetActive(false);
        painelM5Ativo = false;
        Smute.GetComponent<mute>().MonitorAtivado = false;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = false;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = false;
        Player.GetComponent<Player>().MonitorAtivado = false;

    }


    public void verificarIndice()
    {
        if (texto == "2")
        {
            Key.GetComponent<Key>().indiceCorreto = true;
        }
        else
        {
            ConsoleERRO.GetComponent<TextMeshProUGUI>().text = "Valor do indice incorreto";
            ConsoleERRO.SetActive(true);

        }
    }


}
