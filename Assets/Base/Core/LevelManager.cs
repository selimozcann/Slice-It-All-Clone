using UnityEngine;
public class LevelManager : Singleton<LevelManager>
{
    [Header("Levels")] [SerializeField] private Level[] levels;
    [SerializeField] private Level testLevel;
    [SerializeField] private int levelIndex;

    private void Awake()
    {
        LevelInit();
    }
    private void LevelInit()
    {
        levelIndex = PlayerPrefs.GetInt(StringData.PLAYER);

        if (levels[levelIndex] == null)
        {
            Debug.LogError("Level is not found");
        }
        else
        {
            Level levelObject = testLevel != null ? SpawnLevel(testLevel) : SpawnLevel(levels[levelIndex]);
        }
    }
    private Level SpawnLevel(Level level) => Instantiate(level,Vector3.zero,Quaternion.identity);
    public void NextLevel() => PlayerPrefs.SetInt(StringData.PLAYER, levelIndex + 1);
    public void RestartLevel() => PlayerPrefs.SetInt(StringData.PLAYER, levelIndex);
}

