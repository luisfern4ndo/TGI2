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

        else if (!colidPlayer || Input.GetKeyDown(KeyCode.X) && painelM2Ativo || Input.GetKeyDown(KeyCode.KeypadEnter) && painelM2Ativo)
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
        Smute.GetComponent<mute>().m2 = false;
        CanvasPauseRestart.GetComponent<Pause>().m2 = false;
        CanvasPauseRestart.GetComponent<Restart>().m2 = false;
        Player.GetComponent<Player>().m2 = false;

    }
    public void P2Continuar()
    {
        painelM2.SetActive(false);
        painelM2Ativo = false;
        Smute.GetComponent<mute>().m2 = true;
        CanvasPauseRestart.GetComponent<Pause>().m2 = true;
        CanvasPauseRestart.GetComponent<Restart>().m2 = true;
        Player.GetComponent<Player>().m2 = true;

    }
}
