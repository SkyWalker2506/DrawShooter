using System.Collections.Generic;
using UnityEngine;

namespace LineDrawSystem
{
    public class Line 
    {
        #region Field

        LineRenderer line;
        List<Vector3> linePoints=new List<Vector3>();
        Material defaultMaterial;
        string defaultMaterialPath = "Materials/DefaultMaterial";

        #endregion Field

        #region Constructor

        public Line(LineDataWithColor lineDataWithColor, Vector3? startPosition = null)
        {
            if (startPosition == null)
                startPosition = Vector3.zero;
                InitializeLine(lineDataWithColor.LineWidth, (Vector3)startPosition );
            SetColor(lineDataWithColor.LineColor);
        }

        public Line(LineDataWithGradient lineDataWithGradient, Vector3? startPosition = null)
        {
            if (startPosition == null)
                startPosition = Vector3.zero;
            InitializeLine(lineDataWithGradient.LineWidth, (Vector3)startPosition);
            SetGradientColor(lineDataWithGradient.LinerGradient);
        }

        #endregion Constructor

        #region Initialize

        void InitializeLine( float width, Vector3 startPosition)
        {
            line = (new GameObject("Line")).AddComponent<LineRenderer>();
            line.transform.position = startPosition;
            ClearLine();
            AddPoint(startPosition);
            SetWidth(width);
            defaultMaterial = Resources.Load<Material>(defaultMaterialPath);
            SetMaterial(defaultMaterial);
        }

        #endregion Initialize

        #region LinePoint

        public void AddPoint(Vector3 nextPointPosition)
        {
            line.positionCount++;
            line.SetPosition(line.positionCount-1, nextPointPosition);
            linePoints.Add(nextPointPosition);
        }

        public void SetPoints(Vector3[] PointPositions)
        {
            line.SetPositions(PointPositions);
            line.positionCount = PointPositions.Length;
        }

        public Vector3[] GetPoints()
        {
            return linePoints.ToArray();
        }

        public void RemovePointAt(int index)
        {
            linePoints.RemoveAt(index);
            line.positionCount = 0;
            for (int i = 0; i < linePoints.Count; i++)
            {
                AddPoint(linePoints[i]);
            }
        }

        public void ClearLine()
        {
            line.positionCount=0;
            linePoints.Clear();
        }

        #endregion LinePoint

        #region Material
        public void SetMaterial(Material material) => line.material= material;
        #endregion Material

        #region Color

        public void SetStartColor(Color startColor) => line.startColor = startColor;
        public void SetEndColor(Color endColor) => line.endColor = endColor;
        public void SetGradientColor(Gradient gradientColor) => line.colorGradient = gradientColor;

        public void SetColor(Color color)
        {
            SetStartColor(color);
            SetEndColor(color);
        }

        #endregion Color

        #region Size

        public void SetStartWidth(float startWidth) => line.startWidth = startWidth;
        public void SetEndWidth(float endWidth) => line.endWidth = endWidth;

        public void SetWidth(float width)
        {
            SetStartWidth(width);
            SetEndWidth(width);
        }

        #endregion Size
    }

}