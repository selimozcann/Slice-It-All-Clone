using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject winImage;
    [SerializeField] private GameObject failImage;
    
    public void OnStartGame()
    {
        mainUI.SetActive(false);
        PlayerController.Instance.PlayerState = PlayerState.Playing;
    }
    public void OnQuitGame()
    {
        PlayerController.Instance.PlayerState = PlayerState.None;
    }
    public void OnPauseGame()
    {
        PlayerController.Instance.PlayerState = PlayerState.Pause;
    }
    public IEnumerator WinGame()
    {
        yield return new WaitForSeconds(0.2f);
        winImage.SetActive(true);
    }
    public IEnumerator FailGame()
    {
        yield return new WaitForSeconds(0.2f);
        failImage.SetActive(true);
    }
}
