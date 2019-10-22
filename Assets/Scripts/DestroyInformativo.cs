using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInformativo : MonoBehaviour
{
    public GameObject textoInformativo;
    
    
    void Start()
    {
        StartCoroutine("Rotina");
    }

    IEnumerator Rotina()
    {
   
        yield return new WaitForSeconds(7.0f);
        Destroy(textoInformativo);   
        
    }


}
