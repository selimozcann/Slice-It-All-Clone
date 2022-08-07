using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Levels")] 
    [SerializeField] private Level[] levels;
    [SerializeField] private Level testLevel;
    public int levelIndex;

    private void Awake()
    {
        SetLevelIndex();
        LevelInit();
    }
    private void LevelInit()
    {
        Level levelObject = testLevel != null ? SpawnLevel(testLevel) : SpawnLevel(levels[levelIndex]);
    }
    private void SetLevelIndex()
    {
        levelIndex = PlayerPrefs.GetInt(StringData.PLAYER);
        levelIndex = levelIndex == 3 ? 0 : levelIndex;
        CurrentLevel();
    }
    private void CurrentLevel() =>  Debug.Log("Current Level is " + levelIndex + 1);
    private Level SpawnLevel(Level level) => Instantiate(level,level.transform.position,Quaternion.identity);
    public void NextLevelData() => PlayerPrefs.SetInt(StringData.PLAYER, levelIndex + 1);
    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

     
}

