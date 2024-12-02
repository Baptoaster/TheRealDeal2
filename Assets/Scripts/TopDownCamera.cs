using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [Header("Input Data")]
    public RSO_TargetPosition targetPosition;

    [Header("References")]
    [SerializeField] Camera cam;
    
    [Header("Settings")]
    [SerializeField] Vector3 offsetPosition;

    void OnEnable()
    {
        if (cam == null) Debug.LogError("There is no camera attached to the script.");

        targetPosition.onValueChanged += UpdateCameraPosition;
    }

    void Start()
    {
        
    }

    void UpdateCameraPosition(Vector3 targetPosition)
    {
        transform.position = targetPosition + offsetPosition;
    }
}
