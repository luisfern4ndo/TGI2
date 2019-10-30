using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelM2 : MonoBehaviour
{
    public GameObject painelM2;
    public bool colidPlayer;
    public bool painelM2Ativo;

    public Text aperteX;
    public GameObject Smute;
    public GameObject CanvasPauseRestart;
    public GameObject Player;


    void Start()
    {
        aperteX.enabled = false;
    }


    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM2Ativo)
        {
            ativarP2();
            aperteX.enabled = false;

        }

        else if ((Input.GetKeyDown(KeyCode.X) && painelM2Ativo || Input.GetKeyDown(KeyCode.KeypadEnter)) && painelM2Ativo || Input.GetKeyDown(KeyCode.Return) && painelM2Ativo)
        {
            P2Continuar();

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


    public void ativarP2()
    {
        painelM2.SetActive(true);
        painelM2Ativo = true;
        Smute.GetComponent<mute>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = true;
        Player.GetComponent<Player>().MonitorAtivado = true;

    }
    public void P2Continuar()
    {
        painelM2.SetActive(false);
        painelM2Ativo = false;
        Smute.GetComponent<mute>().MonitorAtivado = false;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = false;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = false;
        Player.GetComponent<Player>().MonitorAtivado = false;

    }
}