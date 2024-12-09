using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<GameObject> healthSlider = new List<GameObject>();

    [Header("Input Data")]
    public RSO_PlayerHealth playerHealth;

    private void OnEnable()
    {
        playerHealth.onValueChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        playerHealth.onValueChanged -= UpdateHealth;
    }

    void UpdateHealth(int value)
    {
        healthSlider.value = value;
    }
}
