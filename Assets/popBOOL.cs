using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popBOOL : MonoBehaviour
{

    public GameObject textoBOOL;
    public GameObject textoBOOLclone;
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
            textoBOOLclone = Instantiate(textoBOOL);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(textoBOOLclone);
        }
    }

}


