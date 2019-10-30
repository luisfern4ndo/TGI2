using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelM7 : MonoBehaviour
{
    public GameObject painelM7;
    public bool colidPlayer;
    public bool painelM7Ativo;

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

        if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM7Ativo)
        {
            ativarP7();
            aperteX.enabled = false;

        }

        else if (Input.GetKeyDown(KeyCode.X) && painelM7Ativo || Input.GetKeyDown(KeyCode.KeypadEnter) && painelM7Ativo || Input.GetKeyDown(KeyCode.Return) && painelM7Ativo)
        {
            P7Continuar();

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


    public void ativarP7()
    {
        painelM7.SetActive(true);
        painelM7Ativo = true;
        Smute.GetComponent<mute>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = true;
        Player.GetComponent<Player>().MonitorAtivado = true;

    }
    public void P7Continuar()
    {
        painelM7.SetActive(false);
        painelM7Ativo = false;
        Smute.GetComponent<mute>().MonitorAtivado = false;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = false;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = false;
        Player.GetComponent<Player>().MonitorAtivado = false;

    }
}
