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

        else if (!colidPlayer || Input.GetKeyDown(KeyCode.X) && painelM7Ativo || Input.GetKeyDown(KeyCode.KeypadEnter) && painelM7Ativo)
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
        Smute.GetComponent<mute>().m2 = false;
        CanvasPauseRestart.GetComponent<Pause>().m2 = false;
        CanvasPauseRestart.GetComponent<Restart>().m2 = false;
        Player.GetComponent<Player>().m2 = false;

    }
    public void P7Continuar()
    {
        painelM7.SetActive(false);
        painelM7Ativo = false;
        Smute.GetComponent<mute>().m2 = true;
        CanvasPauseRestart.GetComponent<Pause>().m2 = true;
        CanvasPauseRestart.GetComponent<Restart>().m2 = true;
        Player.GetComponent<Player>().m2 = true;

    }
}
