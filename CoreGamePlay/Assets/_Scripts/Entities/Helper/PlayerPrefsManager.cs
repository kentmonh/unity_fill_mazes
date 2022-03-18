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
        private const string K_money = "Money";
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

        public static int CurrentLevel
        {
            get => GetIntPref(K_currentLevel);
            set => SetIntPref(K_currentLevel, value);
        }

        public static int Money
        {
            get => GetIntPref(K_money);
            set => SetIntPref(K_money, value);
        }
    }
}

