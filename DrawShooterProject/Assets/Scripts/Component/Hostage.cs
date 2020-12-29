using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostage : MonoBehaviour, IBulletInteractable
{
    public void OnBulletInteract()
    {
        GameplayManager.Instance.SetGameLost();
    }
}
