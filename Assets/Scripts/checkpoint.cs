using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public bool noCheck;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision2d)//player colide
    {

        if (collision2d.gameObject.CompareTag("Player"))
        {
            noCheck = true;
            GetComponent<Animator>().SetBool("Checking", noCheck);
        }
    }

    void OnCollisionExit2D(Collision2D collision2d)//para de colidir
    {

        if (collision2d.gameObject.CompareTag("Player"))
        {
            noCheck = false;
            GetComponent<Animator>().SetBool("Checking", noCheck);
        }

    }
}
