using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<Image> heartDisplays = new List<Image>();

    [SerializeField] Sprite emptyHeart;

    [SerializeField] Sprite fullHeart;
    
    [Header("Input Data")]
    public RSO_PlayerHealth playerHealth;
    public RSO_PlayerMaxHealth maxHealth;

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
        for(int i = 0; i < maxHealth.Value; i++)
        {
            if(i < playerHealth.Value)
            {
                heartDisplays[i].sprite = fullHeart;
            }
            else
            {
                heartDisplays[i].sprite = emptyHeart;
            }
        }
    }
}
