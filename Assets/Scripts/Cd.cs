using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd : MonoBehaviour
{

    public GameObject cd;
    public GameObject inimigo;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("Player"))
        {
            Destroy(cd);
            inimigo.GetComponent<EnemyHorizonalInativo>().inativo = false;
        }

    }

    public void OnTriggerExit2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("Player"))
        {
            

        }

    }


}
