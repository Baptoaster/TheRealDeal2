using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody playerRigidbody;

    [Header("Settings")]
    [SerializeField] float movementSpeed = 0.5f;

    [Header("Output Data")]
    public RSO_TargetPosition playerPosition;

    Vector3 movementDirection;
    
    void OnEnable()
    {
        if (playerRigidbody == null) Debug.LogError("There is no rigidbody attached to the script.");
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new (Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (movementDirection != Vector3.zero)
        {
            Vector3 newPosition = transform.position + movementDirection * movementSpeed;
            Vector3 newOrientation = movementDirection.normalized;
            Quaternion newRotation = Quaternion.LookRotation(newOrientation, Vector3.up);
            playerRigidbody.Move(newPosition, newRotation);
        }

        playerPosition.Value = transform.position;
    }
}
