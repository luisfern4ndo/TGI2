using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))] // obrigatorio player ter rigidbody2d
public class Player : MonoBehaviour
{

    public float velocidade;
    public int lives;
    public int colecionaveis;
    public int cd;
    public GameObject cdConsole;
    public GameObject cd2Console;
    public GameObject ConsoleKey;
    public Text TextLives;
    public Text TextColecionaveis;
    public GameObject lastCheckpoint;
    public bool morto;
    public Transform myTransform;
    public respawnPlayer gameRespawnManager;
    public GameObject blood;
    Rigidbody2D rb;
    public bool MonitorAtivado;

    //pulo
    public Transform groundCheck;
    public Transform groundCheck2;
    public bool isGrounded = false;
    public bool isGrounded2 = false;
    public LayerMask whatIsGround;
    public float forcaPulo;



    void Start()
    {
        TextLives.text = lives.ToString();
        TextColecionaveis.text = colecionaveis.ToString();
        cd = 0;
        myTransform = transform;
        gameRespawnManager = FindObjectOfType<respawnPlayer>();
        MonitorAtivado = false;
        rb = GetComponent<Rigidbody2D>();

    }

    void configRB()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        
    }
    void configPadrao()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.WakeUp();

    }

    void Update()
    {

        if (!MonitorAtivado)
        {

            configPadrao();
            float movimento = Input.GetAxis("Horizontal");
            Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.velocity = new Vector2(movimento * velocidade, rigidBody.velocity.y);


            //NovoPulo
            isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, whatIsGround);
            isGrounded2 = Physics2D.Linecast(transform.position, groundCheck2.position, whatIsGround);


            if (Input.GetKeyDown(KeyCode.Space) && isGrounded || Input.GetKeyDown(KeyCode.Space) && isGrounded2)
            {
                rigidBody.AddForce(new Vector2(0, forcaPulo)); //altura

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
        else
        {

            configRB();
            GetComponent<Animator>().SetBool("walking", false);

        }

    }

    void OnCollisionEnter2D(Collision2D collision2d)//player colide
    {
        if (collision2d.gameObject.CompareTag("colecionaveis"))
        {
            collision2d.gameObject.SetActive(false);
            colecionaveis++;
            TextColecionaveis.text = colecionaveis.ToString();
        }

        if (collision2d.gameObject.CompareTag("Key"))
        {
            collision2d.gameObject.SetActive(false);
            ConsoleKey.SetActive(true);
        }

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
        if (collision2d.gameObject.CompareTag("colecionaveis"))
        {
            collision2d.gameObject.SetActive(false);
            colecionaveis++;
            TextColecionaveis.text = colecionaveis.ToString();
        }

        if (collision2d.gameObject.CompareTag("Cd"))
        {
            cdConsole.SetActive(true);
            cd++;
        }
        if (collision2d.gameObject.CompareTag("Cd2"))
        {
            cd2Console.SetActive(true);
            cd++;
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
