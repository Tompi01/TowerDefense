using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lobbyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("Scenes/select_map/mapSelector");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
