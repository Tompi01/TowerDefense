using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TurretMultiCible : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private CircleCollider2D Range;

    public List<GameObject> listEnemy = new List<GameObject>();

    [SerializeField] public float intervalScan = 1f;

    [SerializeField] public float doneDammage = 1f;


    void OnTriggerEnter2D(Collider2D col)
    {
        listEnemy.Add(col.gameObject);

        print("Un objet est rentré");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        listEnemy.Remove(col.gameObject);
        print("Un objet est sortie");
    }

    void Start()
    {
        InvokeRepeating("Dommage", 0f, MathF.Abs(intervalScan));
        Range.radius = 1.7f;
    }

    void Dommage()
    {
        if (listEnemy.Count > 0)
        {
            Vector3 dir = listEnemy[0].transform.position - transform.position;
            Debug.DrawRay(transform.position, dir, Color.red, 0.05f);
            for (int i = 0; i < listEnemy.Count; i++)
            {
                listEnemy[i].GetComponent<EnemyStat>().TakeDamage(doneDammage);
            }

            Debug.Log(this.name + " à toucher une cibles !");
        }
    }

}