using System;
using System.Collections.Generic;
using System.Linq;
using _GameData.Scripts.Controllers;
using UnityEngine;

namespace _GameData.Scripts
{
    public static class Extensions
    {
        public static Vector3 TransformToXZ(this Vector3 source)
        {
            return new Vector3(source.x, 0, source.y);
        }

        

        public static Vector3 SafeLookRotation(this Vector3 source)
        {
            return source == Vector3.zero ? Vector3.forward : source;
        }

        public static IEnumerable<T> ExceptQueue<T>(this IEnumerable<T> original, IEnumerable<T> except)
        {
            return new Queue<T>(original.ToList().Except(except.ToList()).ToList());
        }
    }

   
}