using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolAtivar : MonoBehaviour
{
    GameObject floatPai;
    public GameObject boxBOOL;
   
    void Start()
    {
        floatPai = gameObject.transform.parent.gameObject;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("boxBOOL"))
        {
            floatPai.GetComponent<LocalBoxAtivar>().bBOOLAtivo = true;
            boxBOOL.GetComponent<Animator>().SetBool("Ativado", true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision2d)
    {

        if (collision2d.gameObject.CompareTag("boxBOOL"))
        {
            floatPai.GetComponent<LocalBoxAtivar>().bBOOLAtivo = false;
            boxBOOL.GetComponent<Animator>().SetBool("Ativado", false);
        }
    }

}
