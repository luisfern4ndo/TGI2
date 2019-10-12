using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelM1 : MonoBehaviour
{
    public GameObject painelM1;
    public bool colidPlayer;
    public GameObject objectToDestroy;
    public bool painelM1Ativo;


    public void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM1Ativo)
            {
                ativarP1();
            }

            else if (!colidPlayer || Input.GetKeyDown(KeyCode.X) && painelM1Ativo)
            {
                P1Continuar();
            }


            if (Input.GetKeyDown(KeyCode.F10) && painelM1Ativo)
            {
                P1Continuar();
                DestroyGameObject();
            }

        }

    }

        public void OnTriggerEnter2D(Collider2D collision2d)
        {
            if (collision2d.gameObject.CompareTag("Player"))
            {
                colidPlayer = true;

            }

        }

        public void OnTriggerExit2D(Collider2D collision2d)
        {
            if (collision2d.gameObject.CompareTag("Player"))
            {
                colidPlayer = false;

            }
        }


        public void ativarP1()
        {
            painelM1.SetActive(true);
            painelM1Ativo = true;

    }
        public void P1Continuar()
        {
            painelM1.SetActive(false);
            painelM1Ativo = false;

        }

    public void DestroyGameObject()
    {

        Destroy(objectToDestroy);


    }



}
