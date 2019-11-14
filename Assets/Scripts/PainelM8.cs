using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelM8 : MonoBehaviour
{
    public GameObject painelM8;
    public bool colidPlayer;
    public bool painelM8Ativo;
    public Text aperteX;
    public GameObject Smute;
    public GameObject CanvasPauseRestart;
    public GameObject Player;
    public GameObject painelQuestões;
    public AudioSource xClique;

    void Start()
    {
        aperteX.enabled = false;
    }


    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM8Ativo)
        {
            ativarP8();
            aperteX.enabled = false;

        }

        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && painelM8Ativo || Input.GetKeyDown(KeyCode.Return) && painelM8Ativo)
        {
            chamarQuest();

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


    public void ativarP8()
    {
        painelM8.SetActive(true);
        painelM8Ativo = true;
        Smute.GetComponent<mute>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = true;
        Player.GetComponent<Player>().MonitorAtivado = true;
        GameObject.Find("btIniciarQuest").GetComponent<Button>().Select();
        xClique.Play();

    }
    public void chamarQuest()
    {
        painelM8.SetActive(false);
        painelQuestões.SetActive(true);
        painelM8Ativo = false;

    }
}
