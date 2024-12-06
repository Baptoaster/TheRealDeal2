using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [Header("Reference")]
    public PlayerController playerController;

    [Header("Input Events")]
    public RSE_LevelStarted levelStarted;
    public RSE_Win win;

    private void OnEnable()
    {
        levelStarted.Fire += WarpPlayer;
        win.Fire += WarpPlayer;
    }

    private void OnDisable()
    {
        levelStarted.Fire -= WarpPlayer;
        win.Fire -= WarpPlayer;
    }

    private void Start()
    {
        WarpPlayer();
    }

    void WarpPlayer()
    {
        playerController.Teleport(transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1);
    }
}
