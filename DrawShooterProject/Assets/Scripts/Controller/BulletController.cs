using SequentialMovementSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Vector3[] bulletMovePoints;
    SequentialMoveController sequentialMoveController;
    Bullet bullet;
    [SerializeField] GameObject bulletPrefab;

    private void Awake()
    {
        bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
        bullet.gameObject.SetActive(false);
        sequentialMoveController = new GameObject("SequentialMoveController ").AddComponent<SequentialMoveController>();
        sequentialMoveController.SetMoveObject(bullet.transform);
    }

    private void OnEnable()
    {
        sequentialMoveController.OnMoveEnded += OnBulletReachedDestination;
    }

    private void OnDisable()
    {
        sequentialMoveController.OnMoveEnded -= OnBulletReachedDestination;
    }

    public void SetBulletMovePoints(Vector3[] movePoints)
    {
        bulletMovePoints = movePoints;
        sequentialMoveController.SetMoveData(new SequentialMoveData(bulletMovePoints));
    }

    public void StartMovingBullet()
    {
        bullet.gameObject.SetActive(true);
        sequentialMoveController.StartMovingObject();
    }

    public void StopMovingBullet()
    {
        sequentialMoveController.StopMovingObject();
    }

    public void ResetBullet()
    {
        StopMovingBullet();
        bullet.gameObject.SetActive(false);
    }

    void OnBulletReachedDestination()
    {
        GameplayManager.Instance.ResetGame();
    }
}
