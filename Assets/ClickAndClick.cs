using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndClick : MonoBehaviour
{

    public Sprite spriteSuiveurPrefab; 
    public GameObject spriteSuiveurInstance;

    [SerializeField]
    GameObject turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Click on button, instantiate sprite on mouse position, secondo : when instantiate
    // follow mouse 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;   

            if (spriteSuiveurInstance == null)
            {
                spriteSuiveurInstance = Instantiate(turret, mousePosition, Quaternion.identity);
            }
        }
    }

   
}
