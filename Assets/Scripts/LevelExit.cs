using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [Header("Output Events")]
    public RSE_Win win;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            win.Fire.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1);
    }
}
