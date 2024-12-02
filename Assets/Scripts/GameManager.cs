using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Output Events")]
    [SerializeField] RSE_LevelStarted levelStarted;

    private void Start()
    {
        levelStarted.Fire?.Invoke();
    }
}
