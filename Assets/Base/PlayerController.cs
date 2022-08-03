using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [Header("PlayerState")]
    [SerializeField]  private PlayerState playerState;
    public PlayerState PlayerState { get => playerState; set => playerState = value; }
    private void Update()
    {
        switch (PlayerState)
        {
            case PlayerState.None:
                break;
            case PlayerState.Playing:
                break;
            case PlayerState.Pause:
                break;
            case PlayerState.Fail:
                break;
            case PlayerState.Win:
                break;
        }
    }
}
