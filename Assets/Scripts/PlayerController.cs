using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody playerRigidbody;

    [Header("Settings")]
    [SerializeField] float movementSpeed = 0.5f;
    [SerializeField] float maxMovementSpeed = 2f;

    [Header("Output Data")]
    public RSO_TargetPosition playerPosition;

    Vector3 movementDirection;
    
    void OnEnable()
    {
        if (playerRigidbody == null) Debug.LogError("There is no rigidbody attached to the script.");
    }

    private void Start()
    {
        playerRigidbody.maxLinearVelocity = maxMovementSpeed;
    }

    void Update()
    {
        movementDirection = new (Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));

        if (movementDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movementDirection.normalized, Vector3.up);
            playerRigidbody.MoveRotation(newRotation);
        }

        playerPosition.Value = transform.position;
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddForce(movementDirection.normalized * movementSpeed);
    }
}
