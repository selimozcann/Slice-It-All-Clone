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
