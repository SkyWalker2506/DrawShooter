using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IBulletInteractable
{
    public static Action OnBulletInteractedWithEnemy;

    public void OnBulletInteract()
    {
        OnBulletInteractedWithEnemy?.Invoke();
        gameObject.SetActive(false);
    }
}
