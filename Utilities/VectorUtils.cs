using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/* 
 * Author: 	Noel Watters
 * Date:	04/06/2021
 */

namespace UnityEngine
{
    public static class VectorUtils
    {
        /// <summary>
        /// Returns a vector that has been rotated around an axis by a given number of degrees
        /// </summary>
        public static Vector3 RotateAroundAxis(this Vector3 point, Vector3 axis, float angle)
        {
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            return q * point; //Note: q must be first (point * q wouldn't compile)
        }

        /// <summary>
        /// Rotates a 2D vector by a certain number of degrees
        /// </summary>
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            float radians = degrees * Mathf.Deg2Rad;
            float sin = Mathf.Sin(radians);
            float cos = Mathf.Cos(radians);

            float tx = v.x;
            float ty = v.y;

            return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
        }

        /// <summary>
        /// Checks whether a specified point is within the given radius from an origin point.
        /// </summary>
        /// <param name="originPoint">The origin point that the radius extends from.</param>
        /// <param name="pointToCheck">The specified point to check.</param>
        /// <param name="originRangeRadius">The radius around the origin point that the specified point can be within.</param>
        /// <returns>Whether the given pointToCheck is in the range of the given originPoint.</returns>
        public static bool CheckPointIsInRadius(Vector3 originPoint, Vector3 pointToCheck, float originRangeRadius)
        {
            return Vector3.Distance(originPoint, pointToCheck) < originRangeRadius;
        }
    }
}