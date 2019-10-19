using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolAtivar : MonoBehaviour
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
        if (collision2d.gameObject.CompareTag("boxBOOL"))
        {
            floatPai.GetComponent<LocalBoxAtivar>().bBOOLAtivo = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision2d)
    {

        if (collision2d.gameObject.CompareTag("boxBOOL"))
        {
            floatPai.GetComponent<LocalBoxAtivar>().bBOOLAtivo = false;
        }
    }

}
