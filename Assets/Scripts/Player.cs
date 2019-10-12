using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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


    void Start()
    {
        TextLives.text = lives.ToString();
        TextKeys.text = keys.ToString() + " / 5";
        myTransform = transform;

    }

    void Update()
    {

        float movimento = Input.GetAxis("Horizontal");
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(movimento*velocidade, rigidBody.velocity.y);

        //rotação do personagem
        if (movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX=true; 
        }else if(movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //animação walking
        if(movimento <0 || movimento > 0)
        {
            GetComponent<Animator>().SetBool("walking", true);
        }
        else {
            GetComponent<Animator>().SetBool("walking", false);
        }

        //pulo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)  
        {
            rigidBody.AddForce(new Vector2(0, forcaPulo)); //altura
        }

        //animação morto
        if (morto)
        {
            GetComponent<Animator>().SetBool("morte", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("morte", false);
        }

    }

    void OnCollisionEnter2D(Collision2D collision2d)//player colide
    {
        if (collision2d.transform.tag == "Hplataforma")
        {
            myTransform.parent = collision2d.transform;
            isGrounded = true;
        }

        if (collision2d.transform.tag == "Checkpoint")
        {
            isGrounded = true;
        }

        if (collision2d.gameObject.CompareTag("Inimigo") || collision2d.gameObject.CompareTag("Laser"))  // MORRENDO HAHAHA
        {
            lives--;
            morto = true;

            if (lives < 0)
            {
                
                Invoke("RestartGame", 0.1f);
            }
            else
            {
                
                Invoke("Perdeu", 0.1f);

            }
        }

        

    }
    void OnCollisionExit2D(Collision2D collision2d)//para de colidir
    {

        if (collision2d.transform.tag == "Hplataforma")
        {
            myTransform.parent = null;
            isGrounded = false;
        }

        if (collision2d.transform.tag == "Checkpoint")
        {
            isGrounded = false;
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
            morto = true;

            if (lives < 0)
            {
                Invoke("RestartGame", 0.1f);
            }
            else
            {
                Invoke("Perdeu", 0.1f);
                
            }
        }


    }
    public void OnTriggerExit2D(Collider2D collision2d)
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Inicio");
        
    }

    public void Perdeu()
    {
        transform.position = lastCheckpoint.transform.position;
        morto = false;
        TextLives.text = lives.ToString();
        
    }

}
