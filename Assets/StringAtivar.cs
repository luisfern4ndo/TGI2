using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringAtivar : MonoBehaviour
{
    GameObject floatPai;
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
        }

    }
    private void OnTriggerExit2D(Collider2D collision2d)
    {

        if (collision2d.gameObject.CompareTag("boxSTRING"))
        {
            floatPai.GetComponent<LocalBoxAtivar>().bSTRINGAtivo = false;
        }
    }
}
