using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<IBulletInteractable>();
        if (interactable != null)
            interactable.OnBulletInteract();
    }
    
}
