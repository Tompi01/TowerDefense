using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
   public void launchMap(string s_map)
    {
        SceneManager.LoadScene(s_map, LoadSceneMode.Single);
    }
}
