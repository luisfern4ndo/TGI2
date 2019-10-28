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
        painelM4Ativo = false;
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
        Smute.GetComponent<mute>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = true;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = true;
        Player.GetComponent<Player>().MonitorAtivado = true;
        GameObject.Find("InputMoveIf").GetComponent<TMP_InputField>().Select();

    }
    public void P4Continuar()
    {
        painelM4.SetActive(false);
        painelM4Ativo = false;
        Smute.GetComponent<mute>().MonitorAtivado = false;
        CanvasPauseRestart.GetComponent<Pause>().MonitorAtivado = false;
        CanvasPauseRestart.GetComponent<Restart>().MonitorAtivado = false;
        Player.GetComponent<Player>().MonitorAtivado = false;

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
