using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawnPlayer : MonoBehaviour
{
    public float respawnDelay;
    public Player gamePlayer;

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
        Invoke("Restart", 3f);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Cena 2 Inicio");
    }

}
