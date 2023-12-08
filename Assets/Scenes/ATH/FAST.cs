using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAST : MonoBehaviour
{
    // Start is called before the first frame update
    public void Faster()
    {
        switch (Time.timeScale)
        {
            case 1:
                Time.timeScale = 5;
                break;
            case 5:
                Time.timeScale = 1;
                break;
        }
    }
}
