using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Porta : MonoBehaviour
{
    public Player gamePlayer;
    public float respawnDelay = 2f;
    public GameObject nextPorta;
    public Text aperteX;
    public bool colidPlayer;
    public bool desbloquear;
    public GameObject ConsoleErro;
    public GameObject ConsoleInformativo;


    void Start()
    {
        gamePlayer = FindObjectOfType<Player>();
        aperteX.enabled = false;
        colidPlayer = false;
        desbloquear = false;
}

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X) && colidPlayer && desbloquear)
        {
           AtravessarPorta();
            aperteX.enabled = false;

        }else if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !desbloquear)
        {
            if (gamePlayer.GetComponent<Player>().keys >= 1)
            {
                desbloquear = true;
                ConsoleInformativo.GetComponent<TextMeshProUGUI>().text = "PORTA DESTRANCADA";
                ConsoleInformativo.SetActive(true);
                gamePlayer.GetComponent<Player>().keys--;
                gamePlayer.GetComponent<Player>().TextKeys.text = gamePlayer.GetComponent<Player>().keys.ToString();
            }
            else
            {
                ConsoleErro.GetComponent<TextMeshProUGUI>().text = "A porta está trancada, você precisa de uma chave";
                ConsoleErro.SetActive(true);
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("Player"))
        {
            aperteX.enabled = true;
            colidPlayer = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("Player"))
        {
            aperteX.enabled = false;
            colidPlayer = false;
        }
    }




    public void AtravessarPorta()
    {
        gamePlayer.gameObject.SetActive(false);
        StartCoroutine("AtravessarCoroutine");
    }

    public IEnumerator AtravessarCoroutine()
    {

        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = nextPorta.transform.position;
        gamePlayer.gameObject.SetActive(true);
    }

}
