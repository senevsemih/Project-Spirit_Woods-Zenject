using System.Collections.Generic;
using UnityEngine;

namespace _Game_.Code.Scripts.Other
{
    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = list.Count - 1; i > 1; i--)
            {
                var j = Random.Range(0, i + 1);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }
    }
}