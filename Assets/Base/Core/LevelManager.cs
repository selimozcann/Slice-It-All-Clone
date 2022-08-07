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
        LevelInit();
    }
    private void LevelInit()
    {
        levelIndex = levelIndex >= 2  ? 0 : PlayerPrefs.GetInt(StringData.PLAYER);
        Level levelObject = testLevel != null ? SpawnLevel(testLevel) : SpawnLevel(levels[levelIndex]);
    }
    private Level SpawnLevel(Level level) => Instantiate(level,level.transform.position,Quaternion.identity);
    public void NextLevelData() => PlayerPrefs.SetInt(StringData.PLAYER, levelIndex + 1);
    public void RestartLevelData() => PlayerPrefs.SetInt(StringData.PLAYER, levelIndex);
    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

     
}

