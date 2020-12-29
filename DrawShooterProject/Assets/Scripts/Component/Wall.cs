using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IBulletInteractable
{
    public void OnBulletInteract()
    {
        GameplayManager.Instance.ResetGame();
    }
}
