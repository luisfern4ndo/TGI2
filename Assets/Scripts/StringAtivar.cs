using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringAtivar : MonoBehaviour
{
    GameObject floatPai;
    public GameObject boxString;
   
    void Start()
    {
        floatPai = gameObject.transform.parent.gameObject;
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("boxSTRING"))
        {
            floatPai.GetComponent<LocalBoxAtivar>().bSTRINGAtivo = true;
            boxString.GetComponent<Animator>().SetBool("Ativado", true);
            boxString.GetComponent<TargetJoint2D>().enabled = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision2d)
    {

        if (collision2d.gameObject.CompareTag("boxSTRING"))
        {
            floatPai.GetComponent<LocalBoxAtivar>().bSTRINGAtivo = false;
            boxString.GetComponent<Animator>().SetBool("Ativado", false);
        }
    }
}
