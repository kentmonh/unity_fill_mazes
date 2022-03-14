using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Entities.Helper;

namespace _Scripts.Entities.Menu
{
    public class TextStageLevelController : MonoBehaviour
    {
        public static Text TextStageLevel { get; set; }

        void Awake()
        {
            TextStageLevel = GetComponentInChildren<Text>();
        }
    }
}

