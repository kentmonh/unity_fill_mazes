using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Entities.GamePlay
{
    public class TextGameLevelController : MonoBehaviour
    {
        public static Text TextGameLevel { get; set; }

        void Awake()
        {
            TextGameLevel = GetComponent<Text>();
        }
    }
}

