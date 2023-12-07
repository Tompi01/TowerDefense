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
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("Scenes/Lobby/lobby", LoadSceneMode.Single);
    }
   
    public void Resume()
    {
        canvas.enabled = false;
        Debug.Log("Resume");
    }
}
