using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{

    public float HP = 100;

    public void TakeDamage (float x)
    {
        HP -= x;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
