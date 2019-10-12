using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : MonoBehaviour
{
    private bool colidde = false;
    public float move = -2;

    void Start()
    {

    }
    void Update()
    {
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
