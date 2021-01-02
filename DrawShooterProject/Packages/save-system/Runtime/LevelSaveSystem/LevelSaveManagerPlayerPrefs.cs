using UnityEngine;

namespace SaveSystem.Level
{
    public class LevelSaveManagerPlayerPrefs : LevelSaveManager
    {
        const string CurrentLevelKey = "CurrentLevel";

        public override int GetCurrentLevel()
        {
            return PlayerPrefs.GetInt(CurrentLevelKey,1);
        }

        public override void SetCurrentLevel(int level)
        {
            PlayerPrefs.SetInt(CurrentLevelKey,level);
        }
    }
}