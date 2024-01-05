using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            LifeSystem playerLifeSystem = other.GetComponent<LifeSystem>();

            if (playerLifeSystem != null)
            {
                // Définir le nouveau point de réapparition
                playerLifeSystem.SetRespawnPoint(transform.position);

                // Détruire le cube de spawnpoint après l'avoir touché (facultatif)
                // Destroy(gameObject);
            }
        }
    }
}