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

    public GameObject caixaFLOAT;
  

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
            caixaFLOAT.GetComponent<Animator>().SetBool("Ativado", true);
            caixaFLOAT.GetComponent<TargetJoint2D>().enabled = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision2d)
    {

        if (collision2d.gameObject.CompareTag("boxFLOAT"))
        {
            bFLOATAtivo = false;
            caixaFLOAT.GetComponent<Animator>().SetBool("Ativado", false);
        }
    }
    public void DestroyGameObject()
    {
        if (!destruido)
        {
            Destroy(objectToDestroy1);
            Destroy(objectToDestroy2);
            Destroy(objectToDestroy3);
            ConsoleInformativo.GetComponent<TextMeshProUGUI>().text = "Valores atribuidos corretamente, passagem liberada!";
            ConsoleInformativo.SetActive(true);
        }
    }
   


}

