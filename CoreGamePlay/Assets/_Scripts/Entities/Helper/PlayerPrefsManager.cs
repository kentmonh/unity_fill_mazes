using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Entities.Helper
{
    public class PlayerPrefsManager
    {
        #region Player Pref Keys
        private const string K_currentStage = "CurrentStage";
        private const string K_currentLevel = "CurrentLevel";
        #endregion

        private static void SetIntPref(string name, int value)
        {
            PlayerPrefs.SetInt(name, value);
            PlayerPrefs.Save();
        }

        private static int GetIntPref(string name, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(name, defaultValue);
        }

        public static int CurrentStage
        {
            get => GetIntPref(K_currentStage);
            set => SetIntPref(K_currentStage, value);
        }
    }
}

