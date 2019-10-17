using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelM1 : MonoBehaviour
{
    public GameObject painelM1;
    public bool colidPlayer;
    public GameObject objectToDestroy;
    public bool painelM1Ativo;

    public Text aperteX;


    void Start()
    {
        aperteX.enabled = false;

    }


    public void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.X) && colidPlayer && !painelM1Ativo)
            {
                ativarP1();
                aperteX.enabled = false;

        }

            else if (!colidPlayer || Input.GetKeyDown(KeyCode.X) && painelM1Ativo)
            {
                P1Continuar();
                
            }


            if (Input.GetKeyDown(KeyCode.KeypadEnter) && painelM1Ativo)
            {
                P1Continuar();
                DestroyGameObject();
            }


    }

        public void OnTriggerEnter2D(Collider2D collision2d)
        {
            if (collision2d.gameObject.CompareTag("Player"))
            {
                colidPlayer = true;
                aperteX.enabled = true;

        }

        }

        public void OnTriggerExit2D(Collider2D collision2d)
        {
        if (collision2d.gameObject.CompareTag("Player"))
        {
            colidPlayer = false;
            aperteX.enabled = false;
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
