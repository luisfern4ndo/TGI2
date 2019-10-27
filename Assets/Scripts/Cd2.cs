using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cd2 : MonoBehaviour
{

    public GameObject cd;

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
        }

    }

}

