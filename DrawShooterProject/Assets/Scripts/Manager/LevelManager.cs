using SaveSystem.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager  
{
    #region Field

    int gameSceneBuildIndex=1;
    int firstLevelBuildIndex=2;
    LevelSaveManager levelSaveManager = new LevelSaveManagerPlayerPrefs();

    #endregion Field
    
    #region Property

    int currentLevel { get { return levelSaveManager.GetCurrentLevel() ; } }
    int currentLevelBuildIndex { get { return firstLevelBuildIndex + currentLevel - 1; } }

    #endregion Property

    #region Constructor

    public LevelManager(){}

    public LevelManager(int gameSceneBuildIndex, int firstLevelBuildIndex)
    {
        this.gameSceneBuildIndex = gameSceneBuildIndex;
        this.firstLevelBuildIndex = firstLevelBuildIndex;
    }

    #endregion Constructor

    #region LoadLevel

    public void LoadCurrentLevel()
    {
        SceneManager.LoadSceneAsync(currentLevelBuildIndex);
        SceneManager.LoadSceneAsync(gameSceneBuildIndex, LoadSceneMode.Additive);
    }

    public void LoadLevel(int level)
    {
        levelSaveManager.SetCurrentLevel(level);
        LoadCurrentLevel();
    }

    public void LoadNextLevel()
    {
        LoadLevel(currentLevel + 1);
    }

    #endregion LoadLevel

}