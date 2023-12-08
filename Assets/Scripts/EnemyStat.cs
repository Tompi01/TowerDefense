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
            EnemySpawner.main.enemiesAlive--;
            LevelManager.Score += 20;
            LevelManager.Money += 10;
            Destroy(gameObject);
        }
    }
}
