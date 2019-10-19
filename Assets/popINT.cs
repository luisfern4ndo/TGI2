using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popINT : MonoBehaviour
{
    public GameObject textoINT;
    public GameObject textoINTclone;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textoINTclone = Instantiate(textoINT);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(textoINTclone);
        }
    }

}