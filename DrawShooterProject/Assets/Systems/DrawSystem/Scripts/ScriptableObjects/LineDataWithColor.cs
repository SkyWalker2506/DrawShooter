using UnityEngine;

namespace DrawSystem
{
    [CreateAssetMenu(fileName = "LineDataWithColor", menuName = "DrawSystem/LineData/Color", order = 1)]
    public class LineDataWithColor : LineData
    {
        public Color LineColor;
    }

}