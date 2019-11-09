using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntAtivar : MonoBehaviour
{
    GameObject floatPai;
    public GameObject boxINT;
    
    void Start()
    {
        floatPai = gameObject.transform.parent.gameObject;
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("boxINT"))
        {
            floatPai.GetComponent<LocalBoxAtivar>().bINTAtivo = true;
            boxINT.GetComponent<Animator>().SetBool("Ativado", true);
            boxINT.GetComponent<TargetJoint2D>().enabled = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision2d)
    {

        if (collision2d.gameObject.CompareTag("boxINT"))
        {
            floatPai.GetComponent<LocalBoxAtivar>().bINTAtivo = false;
            boxINT.GetComponent<Animator>().SetBool("Ativado", false);
        }
    }
}
