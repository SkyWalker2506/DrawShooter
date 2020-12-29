namespace SaveSystem.Level
{
    public abstract class LevelSaveManager
    {
        public abstract int GetCurrentLevel();
        public abstract void SetCurrentLevel(int level);
    }
}