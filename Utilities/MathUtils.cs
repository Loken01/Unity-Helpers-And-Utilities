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
    public static class MathUtils
    {
        /// <summary>
        /// Allows remapping a value from an original range to a new range
        /// </summary>
        public static float Remap(this float value, float originalMin = -1, float originalMax = 1, float newMin = 0, float newMax = 1)
        {
            float normal = Mathf.InverseLerp(originalMin, originalMax, value);
            return Mathf.Lerp(newMin, newMax, normal);
        }

        /// <summary>
        /// Rounds a float to the nearest value
        /// </summary>
        public static float RoundTo(this float value, float nearest)
        {
            return Mathf.Round(value / nearest) * nearest;
        }

        /// <summary>
        /// Returns the actual modulo of two numbers, where supplying a negative number won't return another negative.
        /// </summary>
        /// <param name="a">RHS of Modulo operation</param>
        /// <param name="b">LHS of Modulo operation</param>
        /// <returns></returns>
        public static float Modulo(float a, float b)
        {
            float r = a % b;
            return r < 0 ? r + b : r;
        }

        /// <summary>
        /// Returns the actual modulo of two numbers, where supplying a negative number won't return another negative.
        /// </summary>
        /// <param name="a">RHS of Modulo operation</param>
        /// <param name="b">LHS of Modulo operation</param>
        /// <returns></returns>
        public static int Modulo(int a, int b)
        {
            int r = a % b;
            return r < 0 ? r + b : r;
        }
    }
}