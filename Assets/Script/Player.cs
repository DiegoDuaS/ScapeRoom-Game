using UnityEngine;

public class Player : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    // Logica para spawnpoint y deathzones
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            levelManager.SetCheckpoint(other.transform.position);
        }

        // Si chocamos con una DeathZone
        if (other.CompareTag("DeathZone"))
        {
            levelManager.InstantDeath(this.gameObject);
        }
    }


}
