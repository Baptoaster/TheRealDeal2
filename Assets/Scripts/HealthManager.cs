using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int maxLife = 100;

    [Header("Output Data")]
    public RSO_PlayerHealth playerHealth;

    [Header("Output Events")]
    public RSE_PlayerDied playerDied;

    private void Start()
    {
        playerHealth.Value = maxLife;
    }

    public void TakeDamage(int damage)
    {
        playerHealth.Value -= damage;

        if (playerHealth.Value <= 0)
        {
            playerDied.Fire();
        }
    }
}
