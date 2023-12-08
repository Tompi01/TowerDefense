using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    [SerializeField]
    private SpriteRenderer sprite;
    private Transform[] _currentPath;

    private void Start()
    {
        int i = 0;
        foreach (var points in LevelManager.main.path)
        {
            _currentPath = LevelManager.main.path.ElementAt(EnemySpawner.main.objetsuper[gameObject]).Value;
            i++;
        }
        target = _currentPath[pathIndex];
    }


    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;


            if (pathIndex == _currentPath.Length)
            {
                EnemySpawner.main.objetsuper.Remove(gameObject);
                EnemySpawner.onEnemyDestroy.Invoke();
                LevelManager.Live -= 10;
                Destroy(gameObject);
                EnemySpawner.main.enemiesAlive--;
                return;
           }
            else
            {
                int i = 0;
                foreach (var points in LevelManager.main.path)
                {
                    
                    _currentPath = LevelManager.main.path.ElementAt(EnemySpawner.main.objetsuper[gameObject]).Value;
                    i++;
                }
                    target = _currentPath[pathIndex];
            }

            
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        if (direction.x < 0)
        {
            sprite.flipX = true;
        } else
        {
            sprite.flipX = false;
        }

        rb.velocity = direction * moveSpeed;
    }
}
