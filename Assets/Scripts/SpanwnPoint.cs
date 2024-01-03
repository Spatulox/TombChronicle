using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            LifeSystem playerLifeSystem = collision.transform.GetComponent<LifeSystem>();

            if (playerLifeSystem != null)
            {
                playerLifeSystem.SetRespawnPoint(transform.position);

                // si on veut que le spawnpoint ne puisse fonctionner que une fois (facultatif)
                // Destroy(gameObject);
            }
        }
    }
}