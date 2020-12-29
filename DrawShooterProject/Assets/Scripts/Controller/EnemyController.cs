using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Enemy[] enemies;
    int enemyLeft;

    private void Awake()
    {
        enemies = FindObjectsOfType<Enemy>();
        enemyLeft = enemies.Length;
    }

    private void OnEnable()
    {
        Enemy.OnBulletInteractedWithEnemy += OnEnemyHit;
    }

    private void OnDisable()
    {
        Enemy.OnBulletInteractedWithEnemy -= OnEnemyHit;
    }

    void OnEnemyHit()
    {
        enemyLeft--;
        if (enemyLeft == 0)
            GameplayManager.Instance.SetGameWon();
    }

    public void ResetEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.gameObject.SetActive(true);
        }
        enemyLeft = enemies.Length;
    }
}
