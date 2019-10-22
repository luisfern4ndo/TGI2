using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalBoxAtivar : MonoBehaviour
{

    public GameObject objectToDestroy1;
    public GameObject objectToDestroy2;
    public GameObject objectToDestroy3;

    public bool bBOOLAtivo;
    public bool bINTAtivo;
    public bool bFLOATAtivo;
    public bool bSTRINGAtivo;

    public GameObject ConsoleInformativo;
    public bool destruido;


    void Start()
    {
    bBOOLAtivo = false;
    bINTAtivo = false;
    bFLOATAtivo = false;
    bSTRINGAtivo = false;
    destruido = false;
   
    }

    
    void Update()
    {
        if(bFLOATAtivo && bINTAtivo && bSTRINGAtivo && bBOOLAtivo)
        {
            DestroyGameObject();
            destruido = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "boxFLOAT")
        {
            bFLOATAtivo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "boxFLOAT")
        {
            bFLOATAtivo = false;
        }
    }

    public void DestroyGameObject()
    {
        if (!destruido)
        {
            Destroy(objectToDestroy1);
            Destroy(objectToDestroy2);
            Destroy(objectToDestroy3);
            ConsoleInformativo.SetActive(true);
        }
    }
   


}

