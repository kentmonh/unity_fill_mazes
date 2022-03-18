using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Utility
{
    public static class GlobalVariables
    {
        // Colors
        public static Color32 black = new Color32(20, 20, 20, 255);
        public static Color32 gray = new Color32(86, 86, 86, 255);
        public static Color32 orange = new Color32(251, 169, 44, 255);

        // Directions
        public static Vector2[] aroundDirections = { Vector2.right, Vector2.down, Vector2.left, Vector2.up };
    }
}