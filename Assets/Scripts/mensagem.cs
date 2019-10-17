using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mensagem : MonoBehaviour
{
    public Text apertex;
    [Range(0.1f, 10.0f)] public float distancia = 3;
    private GameObject player;
    public bool painel = false;

    void Start()
    {
        apertex.enabled = false;
        player = GameObject.FindWithTag("Player");

    }


    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distancia && !painel)
        {
            apertex.enabled = true;
        }
        else
        {
            apertex.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.X))
            {
            painel = true;
            }

    }
}
