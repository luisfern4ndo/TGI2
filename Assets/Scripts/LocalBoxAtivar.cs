using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalBoxAtivar : MonoBehaviour
{

    public GameObject objectToDestroy1;
    public GameObject objectToDestroy2;
    public GameObject objectToDestroy3;

    public GameObject liberado;

    public bool bBOOLAtivo;
    public bool bINTAtivo;
    public bool bFLOATAtivo;
    public bool bSTRINGAtivo;


    void Start()
    {
    bBOOLAtivo = false;
    bINTAtivo = false;
    bFLOATAtivo = false;
    bSTRINGAtivo = false;
   
   
    }

    
    void Update()
    {
        if(bFLOATAtivo && bINTAtivo && bSTRINGAtivo && bBOOLAtivo)
        {
            DestroyGameObject();
            
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
        Destroy(objectToDestroy1);
        Destroy(objectToDestroy2);
        Destroy(objectToDestroy3);
        Instantiate(liberado);
    }
   


}

