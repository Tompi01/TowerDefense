using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EchapMenu : MonoBehaviour
{
    Canvas canvas;
    private void Start()
    {
        canvas = GetComponent<Canvas>();
        Debug.Log(EnemySpawner.main.enemiesAlive);
    }

    public void GotoMenu()
    {
        Time.timeScale = 1;
        StopCoroutine(EnemySpawner.main.StartWave());
        EnemySpawner.main.Leave();
        SceneManager.LoadScene("Scenes/Lobby/lobby");
    }
   
    public void Resume()
    {
        canvas.enabled = false;
        Time.timeScale = 1;
    }
}
