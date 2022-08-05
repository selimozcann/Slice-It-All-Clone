using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGame();
    public static event StartGame OnStartGame;

    public delegate void EndGame();
    public static event EndGame OnEndGame;
}
