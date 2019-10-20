﻿using System.Collections;
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

        else if (!colidPlayer || Input.GetKeyDown(KeyCode.X) && painelM3Ativo)
        {
            P3Continuar();

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

        Pause.ativado = false;
        Restart.ativado = false;
        mute.ativado = false;
        Player.ativado = false;

    }
    public void P3Continuar()
    {
        painelM3.SetActive(false);
        painelM3Ativo = false;
        Pause.ativado = true;
        Restart.ativado = true;
        mute.ativado = true;
        Player.ativado = true;

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