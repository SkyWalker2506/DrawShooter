using UnityEngine;
using LineDrawSystem;
using System;
using TouchSystem;

public class DrawController : MonoBehaviour
{
    #region Field

    Transform startPoint;
    [SerializeField] float startPointRadius=.35f;
    [SerializeField] string startPointTag = "StartPoint";
    [Header("Line")]
    Line line;
    [SerializeField]LineDataWithColor lineData;
    bool isLineAvailableToDraw=true;
    bool isLineStartedToDraw;
    [Header("Touch")]
    TouchController touchController;
    [SerializeField]
    TouchData touchData;

    #endregion Field

    #region Action

    public Action<Vector3[]> DrawEnded;

    #endregion Action


    #region Initialize

    void Awake()
    {
        SetStartPoint();
        touchController = new TouchController(touchData);
        if(startPoint != null)
            line = new Line(lineData,startPoint.position);
    }

    void SetStartPoint()
    {
        var startObject = GameObject.FindGameObjectWithTag(startPointTag);
        if(startObject == null)
            throw new ArgumentNullException("Start Point can't find.");
        else
            startPoint = startObject.transform;
    }

    void OnEnable()
    {
        AddListeners();
    }

    void OnDisable()
    {
        RemoveListeners();
        ((IDisposable)touchController).Dispose();
    }


    private void OnDestroy()
    {
        ((IDisposable)touchController).Dispose();
    }

    #endregion Initialize

    #region Listener

    void AddListeners()
    {
        touchController.OnFirstWorldPointAdded += TryStartDrawing;
        touchController.OnWorldPointAdded += TryAddPointToLine;
        touchController.OnAllWorldPointsCreated += EndDrawing;
    }

    void RemoveListeners()
    {
        touchController.OnFirstWorldPointAdded -= TryStartDrawing;
        touchController.OnWorldPointAdded -= TryAddPointToLine;
        touchController.OnAllWorldPointsCreated -= EndDrawing;
    }

    #endregion Listener
    #region Draw

    void TryStartDrawing()
    {
        if (!isLineAvailableToDraw) return;
             line.ClearLine();
        if (CheckIfFirstPointAtStartPoint())
            StartDrawing();
        else
            isLineAvailableToDraw = false;
    }

    bool CheckIfFirstPointAtStartPoint()
    {
        var firstPoint = touchController.GetFirstWorldPosition();
        firstPoint.y = startPoint.position.y;
        return Vector3.Distance(firstPoint, startPoint.position) < startPointRadius;
    }

    void StartDrawing()
    {
        line.AddPoint(startPoint.position);
    }

    void TryAddPointToLine(Vector3 touchPoint)
    {
        if (!isLineAvailableToDraw) return;
        var position = touchPoint;
        position.y = startPoint.position.y;
        line.AddPoint(position);
    }

    void EndDrawing()
    {
        if (line.GetPoints().Length > 1)
        {
            DrawEnded?.Invoke(line.GetPoints());
            isLineAvailableToDraw = false;
            touchController.StopListeningTouch();
        }
        else
        {
            ResetDrawing();
        }
    }

    public void ResetDrawing()
    {
        line.ClearLine();
        isLineAvailableToDraw = true;
        touchController.StartListeningTouch();

    }

    #endregion Draw

}