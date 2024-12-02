using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] Canvas canvas;

    [Header("Input Events")]
    [SerializeField] RSE_PlayerDied playerDied;

    private void Start()
    {
        Hide();
    }

    private void OnEnable()
    {
        playerDied.Fire += Show;
    }

    private void OnDisable()
    {
        playerDied.Fire -= Show;
    }

    void Show()
    {
        canvas.enabled = true;
    }

    void Hide()
    {
        canvas.enabled = false;
    }
}