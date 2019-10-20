using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popSTRING : MonoBehaviour
{
    public GameObject textoSTRING;
    public GameObject textoSTRINGclone;
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
            textoSTRINGclone = Instantiate(textoSTRING);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(textoSTRINGclone);
        }
    }

}
