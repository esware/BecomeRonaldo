using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dev.Scripts
{
    public static class RecordPath
    {
        private static readonly List<Vector3> Positions =  new();
        public static List<Vector3> GetPositions() => Positions;
        

        #region Custom Methods
        
        public static void ClearAllRecord()
        {
            Positions.Clear();
        }
        
        private static readonly float recordingDistance = 1.0f;

        private static Vector3 _lastRecordedPosition;

        public static void RecordMovement(Vector3 position)
        {
            if (Mathf.Abs(position.y -_lastRecordedPosition.y) >= .5f)
            {
                Positions.Add(position);
                _lastRecordedPosition = position; 
            }
        }

        #endregion
    }
}