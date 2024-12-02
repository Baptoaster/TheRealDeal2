using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Slider healthSlider;

    [Header("Input Data")]
    public RSO_PlayerHealth playerHealth;

    private void OnEnable()
    {
        playerHealth.onValueChanged += UpdateHealthSlider;
    }

    void UpdateHealthSlider(int value)
    {
        healthSlider.value = value;
    }
}
