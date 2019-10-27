using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PainelM4 : MonoBehaviour
{
    public GameObject painelM4;
    public bool colidPlayer;
    public bool painelM4Ativo;
    public string texto;
    public TMP_InputField textoinput;
    public GameObject Smute;
    public GameObject CanvasPauseRestart;
    public GameObject Player;
    public GameObject Laser;


    public Text aperteX;
    public GameObject ConsoleERRO;


    void Start()
    {
        aperteX.enabled = false;

    }


    public void Update()
    {
        texto = textoinput.text;

        if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM4Ativo)
        {
            ativarP4();
            aperteX.enabled = false;

        }


        if (Input.GetKeyDown(KeyCode.KeypadEnter) && painelM4Ativo)
        {
            ativarPlataforma();
            P4Continuar();

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


    public void ativarP4()
    {
        painelM4.SetActive(true);
        painelM4Ativo = true;
        Smute.GetComponent<mute>().m3 = false;
        CanvasPauseRestart.GetComponent<Pause>().m3 = false;
        CanvasPauseRestart.GetComponent<Restart>().m3 = false;
        Player.GetComponent<Player>().m3 = false;
        GameObject.Find("InputMoveBool").GetComponent<TMP_InputField>().Select();

    }
    public void P4Continuar()
    {
        painelM4.SetActive(false);
        painelM4Ativo = false;
        Smute.GetComponent<mute>().m3 = true;
        CanvasPauseRestart.GetComponent<Pause>().m3 = true;
        CanvasPauseRestart.GetComponent<Restart>().m3 = true;
        Player.GetComponent<Player>().m3 = true;

    }


    public void ativarPlataforma()
    {
        if (texto == "True")
        {
            AtivarMoveP2.ativar2 = true;
            Laser.SetActive(true);
        }
        else if (texto == "False")
        {
            AtivarMoveP2.ativar2 = false;
            Laser.SetActive(false);

        }
        else
        {
            ConsoleERRO.GetComponent<TextMeshProUGUI>().text = "ERRO! O valor não existe no contexto atual";
            ConsoleERRO.SetActive(true);

        }
    }


}
