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
        if (collision2d.gameObject.CompareTag("Plataforma") || collision2d.gameObject.CompareTag("Hplataforma") || collision2d.gameObject.CompareTag("Checkpoint") || collision2d.gameObject.CompareTag("boxINT") || collision2d.gameObject.CompareTag("boxFLOAT") || collision2d.gameObject.CompareTag("boxSTRING") || collision2d.gameObject.CompareTag("boxBOOL"))
        {
            Player.GetComponent<Player>().isGrounded = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision2d)
   {

        if (collision2d.gameObject.CompareTag("Plataforma") || collision2d.gameObject.CompareTag("Hplataforma") || collision2d.gameObject.CompareTag("Checkpoint") || collision2d.gameObject.CompareTag("boxINT") || collision2d.gameObject.CompareTag("boxFLOAT") || collision2d.gameObject.CompareTag("boxSTRING") || collision2d.gameObject.CompareTag("boxBOOL"))
        {
            Player.GetComponent<Player>().isGrounded = false;
        }
    }


}
