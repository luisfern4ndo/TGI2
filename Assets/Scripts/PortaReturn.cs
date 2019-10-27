using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortaReturn : MonoBehaviour
{
    public Player gamePlayer;
    public float respawnDelay = 2f;
    public GameObject portaReturn;
    public Text aperteX;
    public bool colidPlayer;

    void Start()
    {
        gamePlayer = FindObjectOfType<Player>();
        aperteX.enabled = false;
        colidPlayer = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X) && colidPlayer)
        {
            AtravessarPorta();
            aperteX.enabled = false;

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
        gamePlayer.transform.position = portaReturn.transform.position;
        gamePlayer.gameObject.SetActive(true);
    }

}

