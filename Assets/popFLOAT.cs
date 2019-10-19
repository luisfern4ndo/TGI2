using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popFLOAT : MonoBehaviour
{

    public GameObject textoFLOAT;
    public GameObject textoFLOATclone;

    void Start()
    {
        
    } 
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            textoFLOATclone = Instantiate(textoFLOAT);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(textoFLOATclone);
        }
    }

}
