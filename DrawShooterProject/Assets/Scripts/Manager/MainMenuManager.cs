using SaveSystem.Level;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    #region Field

    LevelManager levelManager = new LevelManager();
    
    #endregion Field

    #region Button

    public void OnStartButtonPressed()
    {
        levelManager.LoadCurrentLevel();
    }

    #endregion Button
}
