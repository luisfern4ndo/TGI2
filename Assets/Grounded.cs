using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject; 
    }

  
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("Plataforma"))
        {
            Player.GetComponent<Player>().isGrounded = true;
        } 
    }



    private void OnTriggerExit2D(Collider2D collision2d)
   {

        if (collision2d.gameObject.CompareTag("Plataforma"))
        {
            Player.GetComponent<Player>().isGrounded = false;
        }
    }


}
