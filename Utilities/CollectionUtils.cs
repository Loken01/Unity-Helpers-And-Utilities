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
    public static class CollectionUtils
    {
        /// <summary>
        /// Returns a random element from an array
        /// </summary>
        public static T GetRandom<T>(this T[] array)
        {
            if (array != null && array.Length > 0)
                return array[Random.Range(0, array.Length)];

            return default(T);
        }

        /// <summary>
        /// Returns a random element from an array
        /// </summary>
        public static T GetRandom<T>(this List<T> list)
        {
            if (list != null && list.Count > 0)
                return list[Random.Range(0, list.Count)];

            return default(T);
        }
    }
}