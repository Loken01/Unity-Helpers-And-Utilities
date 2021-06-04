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
    public static class ColorUtils
    {
        /// <summary>
        /// Copies a colour and changes the alpha to the desired value
        /// </summary>
        /// <param name="color">The colour to alter</param>
        /// <param name="alpha">The new desired alpha</param>
        /// <param name="multiply">If true, the current alpha will be multiplied by the value, rather than replaced</param>
        /// <returns>The colour with the new alpha value</returns>
        public static Color ChangeAlpha(this Color color, float alpha, bool multiply = false)
        {
            return new Color(color.r, color.g, color.b, multiply ? color.a * alpha : alpha);
        }
    }
}