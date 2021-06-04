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
    public static class StringUtils
    {
        /// <summary>
        /// Returns a more beautiful string, in much the same way Unity handles Variable names
        /// </summary>
        public static string Beautify(this string input)
        {
            //Remove specials
            StringBuilder beautyString = new StringBuilder(input.Replace("_", " ").Replace("-", " "));

            //Remove starting spaces
            if (beautyString.Length > 0)
                while (beautyString[0] == ' ')
                    beautyString.Remove(0, 1);

            //Adjust
            for (int i = 0; i < beautyString.Length - 1; i++)
            {
                //Make first letter upper
                if (i == 0 && char.IsLetter(beautyString[i]))
                    beautyString[i] = char.ToUpper(beautyString[i]);

                //Change chars after space to be upper case
                if (beautyString[i] == ' ' && char.IsLetter(beautyString[i + 1]))
                    beautyString[i + 1] = char.ToUpper(beautyString[i + 1]);

                //Add in spaces between low to high case characters
                if (char.IsLower(beautyString[i]) && char.IsUpper(beautyString[i + 1]))
                    beautyString.Insert(i + 1, " ");
            }

            //Now work in reverse for all caps
            for (int i = beautyString.Length - 1; i > 0; i--)
            {
                if (char.IsUpper(beautyString[i - 1]) && char.IsUpper(beautyString[i]))
                    beautyString[i] = char.ToLower(beautyString[i]);
            }

            return beautyString.ToString();
        }
    }
}