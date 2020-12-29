using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuManager : MonoBehaviour
{
    LevelManager levelManager = new LevelManager();

    public void RestartLevel()
    {
        levelManager.LoadCurrentLevel();
    }
}
