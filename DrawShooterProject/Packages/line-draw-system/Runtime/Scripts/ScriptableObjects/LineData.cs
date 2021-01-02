using UnityEngine;

namespace LineDrawSystem
{
    public abstract class LineData : ScriptableObject
    {
        [Range(.1f, 2)]
        public float LineWidth = .25f;
    }

}