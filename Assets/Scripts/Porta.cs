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
    public GameObject ConsoleKey;


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
            if (ConsoleKey.activeInHierarchy)
            {

                aperteX.enabled = false;
                GetComponent<Animator>().SetBool("Destrancada", true);
                ConsoleInformativo.GetComponent<TextMeshProUGUI>().text = "A porta foi aberta";
                ConsoleInformativo.SetActive(true);
                ConsoleKey.SetActive(false);

                StartCoroutine(destrancar());
                
            }
            else
            {
                if (ConsoleInformativo.activeInHierarchy == false) {
                    ConsoleErro.GetComponent<TextMeshProUGUI>().text = "A porta está trancada, você precisa de uma chave";
                    ConsoleErro.SetActive(true);
                }
            }
        }

    }

    IEnumerator destrancar()
    {
        yield return new WaitForSeconds(2f);
        desbloquear = true;
        GetComponent<Animator>().SetBool("Destrancada2", true);
        aperteX.enabled = true;
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
