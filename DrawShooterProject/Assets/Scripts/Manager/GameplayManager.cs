using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] DrawController drawController;
    [SerializeField] BulletController bulletController;
    [SerializeField] EnemyController enemyController;
    [SerializeField] UIController uiController;
    bool isGameEmded;

    public static GameplayManager Instance;


    #region Initialize

    private void Awake()
    {
        if (Instance)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void OnEnable()
    {
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    #endregion Initialize

    #region Listener

    void AddListeners()
    {
        drawController.DrawEnded += OnDrawEnded;
    }

    void RemoveListeners()
    {
        drawController.DrawEnded -= OnDrawEnded;
    }

    #endregion Listener

    #region Draw

    void OnDrawEnded(Vector3[] linePoints)
    {
        bulletController.SetBulletMovePoints(linePoints);
        bulletController.StartMovingBullet();
    }

    public void ResetGame()
    {
        if (isGameEmded) return;
        drawController.ResetDrawing();
        bulletController.ResetBullet();
        enemyController.ResetEnemies();
    }

    #endregion Draw

    #region GameState

    public void SetGameLost()
    {
        isGameEmded = true;
        bulletController.ResetBullet();
        uiController.OpenLoseScreen();
    }

    public void SetGameWon()
    {
        isGameEmded = true;
        bulletController.StopMovingBullet();
        uiController.OpenWinScreen();
    }

    #endregion GameState



}
