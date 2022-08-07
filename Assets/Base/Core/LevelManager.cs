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
        SetLevelIndex();
        Level levelObject = testLevel != null ? SpawnLevel(testLevel) : SpawnLevel(levels[levelIndex]);
    }
    private void SetLevelIndex()
    {
        if (levelIndex > 2)
        {
            PlayerPrefs.DeleteKey(StringData.PLAYER);
            
        }
        else
        {
            levelIndex = PlayerPrefs.GetInt(StringData.PLAYER);
            
        }
        CurrentLevel();
    }
    private void CurrentLevel() =>  Debug.Log("Current Level is " + levelIndex + 1);
    private Level SpawnLevel(Level level) => Instantiate(level,level.transform.position,Quaternion.identity);
    public void NextLevelData() => PlayerPrefs.SetInt(StringData.PLAYER, levelIndex + 1);
    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

     
}

