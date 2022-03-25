using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Entities.Helper;
using _Scripts.Entities.GamePlay.Blocks;
using _Scripts.Entities.GamePlay.Lines;
using _Scripts.Entities.GamePlay.Texts;

namespace _Scripts.Entities.GamePlay.LevelFinish
{
    public static class LevelFinishController
    {
        public static void IncreasePlayerPrefs()
        {
            if (PlayerPrefsManager.CurrentLevel < 300)
            {
                PlayerPrefsManager.CurrentLevel += 1;
            }
            else
            {
                PlayerPrefsManager.CurrentStage += 1;
                PlayerPrefsManager.CurrentLevel = 1;
            }
            PlayerPrefsManager.Money += 1;
        }

        public static void RemovePreviousLevel()
        {
            PathLineController.LinePath.Clear();
            InitLineController.NewGame();
            SetupBlocks.NewGame();
        }

        public static void RefreshText()
        {
            TexMoneyController.RefreshMoneyText();
            TextGameLevelController.RefreshGameLevelText();
        }
    }
}

