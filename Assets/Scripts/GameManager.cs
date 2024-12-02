using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] RSE_Win win;
    [SerializeField] RSE_PlayerDied playerDied;
    [SerializeField] RSE_LevelStarted levelStarted;

    private void OnEnable()
    {
        win.Fire += OnWin;
        playerDied.Fire += OnPlayerDeath;
        levelStarted.Fire += OnLevelStart;
    }

    private void OnDisable()
    {
        win.Fire += OnWin;
        playerDied.Fire += OnPlayerDeath;
        levelStarted.Fire += OnLevelStart;
    }

    void OnWin()
    {

    }

    void OnPlayerDeath()
    {

    }

    void OnLevelStart()
    {

    }
}
