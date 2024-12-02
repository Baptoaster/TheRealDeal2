using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int damages = 10;

    private void OnTriggerEnter(Collider other)
    {
        HealthManager playerHealth;

        if (other.TryGetComponent<HealthManager>(out playerHealth))
        {
            playerHealth.TakeDamage(damages);
        }
    }
}
