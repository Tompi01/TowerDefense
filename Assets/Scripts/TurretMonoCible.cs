using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

public class TurretMonoCible : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private CircleCollider2D Range;

    public List<GameObject> listEnemy = new List<GameObject>();

    [SerializeField] public float intervalScan = 1f;

    [SerializeField] public float doneDammage = 1f;

    



    void OnTriggerEnter2D(Collider2D col)
    {
        listEnemy.Add(col.gameObject);

       // print("Un objet est rentré");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        listEnemy.Remove(col.gameObject);
       // print("Un objet est sortie");
    }

    void Start()
    {
        InvokeRepeating("Dommage", 0f, intervalScan);
    }

    void Update()
    {
        if (listEnemy.Count > 0)
        {
            // Get distance between two dots
            double xTotal = Math.Pow(listEnemy[0].transform.position.x - gameObject.transform.position.x, 2);
            double yTotal = Math.Pow(listEnemy[0].transform.position.y - gameObject.transform.position.y, 2);
            double AtoB = Math.Sqrt(xTotal + yTotal);


            // Get angle between two dots
            double angle = Math.Atan2(listEnemy[0].transform.position.y - gameObject.transform.position.y, listEnemy[0].transform.position.x - gameObject.transform.position.x) * (180 / Math.PI) - 90;


            //Apply rotation to tower
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                ((float)angle)
            );
        }
    }


    void Dommage()
    {
        if (listEnemy.Count > 0)
        {
            Vector3 dir = listEnemy[0].transform.position - transform.position;
            Debug.DrawRay(transform.position, dir, Color.red, 0.05f);

            listEnemy[0].GetComponent<EnemyStat>().TakeDamage(doneDammage);
            //Debug.Log(this.name + " à toucher une cibles !");
        }
    }

}