using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Settings")]
    public RSO_PlayerMaxHealth maxHealth;

    [Header("Output Data")]
    public RSO_PlayerHealth playerHealth;

    [Header("Output Events")]
    public RSE_PlayerDied playerDied;

    private void Start()
    {
        playerHealth.Value = maxHealth.Value;
    }

    public void TakeDamage(int damage)
    {
        playerHealth.Value -= damage;

        if (playerHealth.Value <= 0)
        {
            playerDied.Fire?.Invoke();
            playerHealth.Value = maxHealth.Value;
        }
    }
}
