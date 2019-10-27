using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool indiceCorreto;
    Rigidbody2D rb;

    void Start()
    {
        indiceCorreto = false;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {


        if (indiceCorreto)
        {
            configRB();
        }
        
    }

    void configRB()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.WakeUp();
    }

}
