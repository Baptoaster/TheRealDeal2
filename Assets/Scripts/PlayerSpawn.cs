using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [Header("Reference")]
    public Transform playerTransform;

    [Header("Input Events")]
    public RSE_LevelStarted levelStarted;

    private void OnEnable()
    {
        levelStarted.Fire += WarpPlayer;
    }

    void WarpPlayer()
    {
        playerTransform.position = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1);
    }
}
