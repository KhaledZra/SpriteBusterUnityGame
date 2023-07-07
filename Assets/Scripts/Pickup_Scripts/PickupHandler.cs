using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    private enum PickupType
    {
        Health,
        Speed,
        DamageShield,
    }

    [SerializeField] private PickupType pickupType = PickupType.Health;
    [SerializeField] private ActivePickupHandler activePickupHandler;
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
            activePickupHandler.ActivateHealthPickup();
        }
        else if (pickupType == PickupType.Speed)
        {
            activePickupHandler.ActivateSpeedPickup();
        }
        else if (pickupType == PickupType.DamageShield)
        {
            activePickupHandler.ActivateBulletShieldPickup();
        }
    }
}
