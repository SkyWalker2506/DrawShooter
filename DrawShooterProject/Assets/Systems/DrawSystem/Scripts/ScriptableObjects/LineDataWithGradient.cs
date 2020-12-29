using UnityEngine;

namespace DrawSystem
{
    [CreateAssetMenu(fileName = "LineDataWithGradient", menuName = "DrawSystem/LineData/Gradient", order = 2)]
    public class LineDataWithGradient : LineData
    {
        public Gradient LinerGradient;

    }

}