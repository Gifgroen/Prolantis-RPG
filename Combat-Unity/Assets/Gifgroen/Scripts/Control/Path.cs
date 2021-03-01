using UnityEditor;
using UnityEngine;

namespace Gifgroen.Control
{
    public class Path : MonoBehaviour
    {
        public int CycleWaypoint(int oldIndex)
        {
            return (oldIndex + 1) % transform.childCount;
        }

        public Vector3 GetCurrentWaypoint(int current)
        {
            return transform.GetChild(current).position;
        }

#if UNITY_EDITOR
        [SerializeField] private float thickness = 5f;

        [SerializeField] private Color pathColor = Color.green;

        private void OnDrawGizmos()
        {
            Color currentColor = Gizmos.color;
            Gizmos.color = pathColor;
            int waypointCount = transform.childCount;
            for (int i = 0; i < waypointCount; ++i)
            {
                var waypoint = transform.GetChild(i);
                Vector3 waypointPosition = waypoint.position;
                Gizmos.DrawSphere(waypointPosition, 0.25f);

                Vector3 start = waypointPosition;
                Vector3 end = transform.GetChild((i + 1) % waypointCount).position;

                Handles.DrawBezier(start, end, start, end, pathColor, null, thickness);
            }

            Gizmos.color = currentColor;
        }
#endif
    }
}