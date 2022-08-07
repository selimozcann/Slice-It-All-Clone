using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject winImage;
    [SerializeField] private GameObject failImage;
    [SerializeField] private Text tapTapText;
    [SerializeField] private Vector3 targetTapTapVec = new Vector3(0.6f, 0.6f, 1f);

    private int targetFontSize = 75;
    private const string level = "Level";

    private void SetLevelText()
    {
        levelText.text = level + LevelManager.I.levelIndex;
    }
    private void Awake()
    {
        DOTween.KillAll();
    }
    private void Start()
    {
        SetTapTextScale();
    }
    private void SetTapTextScale()
    {
        DOTween.To(()  => tapTapText.fontSize, set=> tapTapText.fontSize  = set, targetFontSize, 0.8f).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
    }
    public void OnStartGame()
    {
        mainUI.SetActive(false);
    }
    public IEnumerator WinGame()
    {
        yield return new WaitForSeconds(0.2f);
        winImage.SetActive(true);
    }
    public void OnFailGame()
    {
        StartCoroutine(FailGameCoroutine());
    }
    private IEnumerator FailGameCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        failImage.SetActive(true);
    }
}
