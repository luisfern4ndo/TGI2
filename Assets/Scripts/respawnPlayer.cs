using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawnPlayer : MonoBehaviour
{
    public float respawnDelay;
    public Player gamePlayer;
    public GameObject GameOverMsg;

    void Start()
    {
        gamePlayer = FindObjectOfType<Player>();
    }
    void Update()
    {
        
    }

    public void Respwan()
    {
        gamePlayer.gameObject.SetActive(false);
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.lastCheckpoint.transform.position;
        gamePlayer.gameObject.SetActive(true);
    }

    public void gameOver()
    {
        gamePlayer.gameObject.SetActive(false);
        Invoke("GAMEOVER", 2f);
    }

    public void GAMEOVER()
    {
        GameOverMsg.SetActive(true);
        StartCoroutine(RestartGameOver());
    }

    IEnumerator RestartGameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Cena 3 Jogo");
    }

}
