using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PainelM6 : MonoBehaviour
{
    public GameObject painelM6;
    public bool colidPlayer;
    public bool painelM6Ativo;
    public string texto;
    public TMP_InputField textoinput;
    public GameObject Smute;
    public GameObject CanvasPauseRestart;
    public GameObject Player;
    public GameObject plataforma1;
    public GameObject plataforma2;
    public GameObject plataforma3;
    public GameObject plataforma4;

    public Text aperteX;
    public GameObject ConsoleERRO;


    void Start()
    {
        aperteX.enabled = false;

    }


    public void Update()
    {
        texto = textoinput.text;

        if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM6Ativo)
        {
            ativarP6();
            aperteX.enabled = false;

        }


        if (Input.GetKeyDown(KeyCode.KeypadEnter) && painelM6Ativo)
        {
            ativarPlataforma();
            P6Continuar();

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


    public void ativarP6()
    {
        painelM6.SetActive(true);
        painelM6Ativo = true;
        Smute.GetComponent<mute>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = true;
        Player.GetComponent<Player>().MonitorAtivado = true;
        GameObject.Find("InputWhile").GetComponent<TMP_InputField>().Select();

    }
    public void P6Continuar()
    {
        painelM6.SetActive(false);
        painelM6Ativo = false;
        Smute.GetComponent<mute>().MonitorAtivado = false;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = false;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = false;
        Player.GetComponent<Player>().MonitorAtivado = false;

    }


    public void ativarPlataforma()
    {
        if (texto == "While 3")
        {
            plataforma1.GetComponent<AtivarWhileMoveP>().ativar = true;
            plataforma2.GetComponent<AtivarWhileMoveP>().ativar = true;
            plataforma3.GetComponent<AtivarWhileMoveP>().ativar = true;
            plataforma4.GetComponent<AtivarWhileMoveP>().ativar = false;
        }
        else
        {
            ConsoleERRO.GetComponent<TextMeshProUGUI>().text = "Escreva While 3, apenas teste";
            ConsoleERRO.SetActive(true);

        }
    }


}