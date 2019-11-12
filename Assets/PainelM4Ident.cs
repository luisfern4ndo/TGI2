using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelM4Ident : MonoBehaviour
{
    public GameObject espinhos1;
    public GameObject espinhos2;
    public GameObject espinhos3;
    public GameObject espinhos4;
    public GameObject espinhos5;

    public GameObject painelM4;
    public bool colidPlayer;
    public bool painelM4Ativo;

    public Text aperteX;
    public GameObject Smute;
    public GameObject CanvasPauseRestart;
    public GameObject Player;

    void Start()
    {
        aperteX.enabled = false;
        StartCoroutine(espinhosDown());
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM4Ativo)
        {
            ativarP4();
            aperteX.enabled = false;

        }

        else if ((Input.GetKeyDown(KeyCode.X) && painelM4Ativo || Input.GetKeyDown(KeyCode.KeypadEnter)) && painelM4Ativo || Input.GetKeyDown(KeyCode.Return) && painelM4Ativo)
        {
            P4Continuar();

        }
    }


    IEnumerator espinhosDown()
    {
        espinhosDown2();
        yield return new WaitForSeconds(1.5f);
        espinhos2.GetComponent<Animator>().SetBool("Down", true);
        espinhos2.GetComponent<Animator>().SetBool("Up", false);
        yield return new WaitForSeconds(1.2f);
        espinhos3.GetComponent<Animator>().SetBool("Down", true);
        espinhos3.GetComponent<Animator>().SetBool("Up", false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(espinhosUp());
        espinhos4.GetComponent<Animator>().SetBool("Down", true);
        espinhos4.GetComponent<Animator>().SetBool("Up", false);

        
    }

   public void espinhosDown2()
    {
        
        espinhos1.GetComponent<Animator>().SetBool("down", true);
        espinhos1.GetComponent<Animator>().SetBool("up", false);      
        espinhos5.GetComponent<Animator>().SetBool("Down", true);
        espinhos5.GetComponent<Animator>().SetBool("Up", false);

    }

    IEnumerator espinhosUp()
    {
        espinhos1.GetComponent<Animator>().SetBool("down", false);
        espinhos1.GetComponent<Animator>().SetBool("up", true);
        yield return new WaitForSeconds(1.2f);
        espinhos2.GetComponent<Animator>().SetBool("Down", false);
        espinhos2.GetComponent<Animator>().SetBool("Up", true);
        espinhosUp2();
        StartCoroutine(espinhosDown());
        yield return new WaitForSeconds(2.2f);
        espinhos5.GetComponent<Animator>().SetBool("Down", false);
        espinhos5.GetComponent<Animator>().SetBool("Up", true);
       
    }
    
    public void espinhosUp2()
    {
        
        espinhos3.GetComponent<Animator>().SetBool("Down", false);
        espinhos3.GetComponent<Animator>().SetBool("Up", true);
        espinhos4.GetComponent<Animator>().SetBool("Down", false);
        espinhos4.GetComponent<Animator>().SetBool("Up", true);
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
}
