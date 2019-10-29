using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizonalInativo : MonoBehaviour
{
    private bool colidde = false;
    public float move = -2;
    public bool inativo;

    void Start()
    {
        inativo = true;
    }
    void Update()
    {
        if (inativo == false)
        {
            GetComponent<Animator>().SetBool("Ativando", true);
            StartCoroutine(ativando());
            
        }
    }


    IEnumerator ativando()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetBool("Ativado", true);
        GetComponent<Rigidbody2D>().velocity = new Vector2(move, GetComponent<Rigidbody2D>().velocity.y);
        if (colidde)
        {
            Flip();
        }
    }


    void Flip()
    {
        move *= -1;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        colidde = false;
    }

    void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("Plataforma"))
        {
            colidde = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("Plataforma"))
        {
            colidde = false;
        }
    }
}
