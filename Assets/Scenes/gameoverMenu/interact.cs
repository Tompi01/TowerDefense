using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interact : MonoBehaviour
{
   public void menu()
    {
        Time.timeScale = 1;
        StopCoroutine(EnemySpawner.main.StartWave());
        EnemySpawner.main.Leave();
        SceneManager.LoadScene("Scenes/Lobby/lobby");
    }

    public void replay()
    {
        Time.timeScale = 1;
        StopCoroutine(EnemySpawner.main.StartWave());
        EnemySpawner.main.Leave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
