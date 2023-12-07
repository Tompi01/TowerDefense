using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class getEchapPressed : MonoBehaviour
{
    [SerializeField]
    private Canvas echap_menu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            echap_menu.enabled = !echap_menu.enabled;
        }
    }
}
