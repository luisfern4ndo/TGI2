using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float forcaPulo;
    public float velocidade;
    public int lives;
    public int keys;
    public Text TextLives;
    public Text TextKeys;
    public GameObject lastCheckpoint;
    public bool morto;
    public bool isGrounded = false;
    public Transform myTransform;
    public respawnPlayer gameRespawnManager;

    public GameObject blood;
    public static bool ativado;


    void Start()
    {
        TextLives.text = lives.ToString();
        TextKeys.text = keys.ToString() + " / 5";
        myTransform = transform;
        gameRespawnManager = FindObjectOfType<respawnPlayer>();
        ativado = true;

    }

    void Update()
    {

        float movimento = Input.GetAxis("Horizontal");

        if (ativado)
        {
            Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.velocity = new Vector2(movimento*velocidade, rigidBody.velocity.y);

        

            //pulo
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rigidBody.AddForce(new Vector2(0, forcaPulo)); //altura
            }
        }

            //rotação do personagem
            if (movimento < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (movimento > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

        //animação walking
        if (movimento < 0 || movimento > 0)
        {
            GetComponent<Animator>().SetBool("walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walking", false);
        }

    }

    void OnCollisionEnter2D(Collision2D collision2d)//player colide
    {
        if (collision2d.transform.tag == "Hplataforma")
        {
            myTransform.parent = collision2d.transform;
        }

        if (collision2d.gameObject.CompareTag("Inimigo"))// MORRENDO HAHAHA
        {
            lives--;
            Instantiate(blood, transform.position, Quaternion.identity);

            if (lives < 0)
            {

                RestartGame();
            }
            else
            {

                Perdeu();

            }
        }

        

    }
    void OnCollisionExit2D(Collision2D collision2d)//para de colidir
    {

        if (collision2d.transform.tag == "Hplataforma")
        {
            myTransform.parent = null;
           
        }

   
    }

    //pegar keys e lives

    public void OnTriggerEnter2D(Collider2D collision2d)
    {
        if (collision2d.gameObject.CompareTag("Key")){
            Destroy(collision2d.gameObject);
            keys++;
            TextKeys.text = keys.ToString() + " / 5";
        }

        if (collision2d.gameObject.CompareTag("Live"))
        {
            Destroy(collision2d.gameObject);
            lives++;
            TextLives.text = lives.ToString();
        }

        if (collision2d.gameObject.CompareTag("CheckOutros"))
        {
            lastCheckpoint = collision2d.gameObject;
            
        }

        if (collision2d.gameObject.CompareTag("deathArea"))
        {
            lives--;
            Instantiate(blood, transform.position, Quaternion.identity);

            if (lives < 0)
            {
                RestartGame();
            }
            else
            {
                Perdeu();
                
            }
        }


    }
    public void OnTriggerExit2D(Collider2D collision2d)
    {
        
    }

    public void RestartGame()
    {
        gameRespawnManager.gameOver();

    }

    public void Perdeu()
    {
        gameRespawnManager.Respwan();
        TextLives.text = lives.ToString();
        
    }

}
