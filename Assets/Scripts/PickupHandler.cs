using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    private enum PickupType
    {
        Health,
        Ammo,
        Speed,
        Damage,
    }

    [SerializeField] private PickupType pickupType = PickupType.Health;
    [SerializeField] private GameObject playerObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPickup();
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    private void OnPickup()
    {
        if (pickupType == PickupType.Health)
        {
            playerObject.GetComponent<HealthHandler>().Heal(1);
        }
        else if (pickupType == PickupType.Ammo)
        {
            
        }
        else if (pickupType == PickupType.Speed)
        {
            
        }
        else if (pickupType == PickupType.Damage)
        {
            
        }
    }
}
