using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Entities.Helper;
using _Scripts.Entities.GamePlay.Blocks;
using _Scripts.Entities.GamePlay.Lines;

namespace _Scripts.Entities.GamePlay.LevelFinish
{
    public class LevelFinishUI : MonoBehaviour
    {
        public static Button NextButton;

        void Awake()
        {
            NextButton = GetComponentInChildren<Button>();
            NextButton.gameObject.SetActive(false);
            NextButton.onClick.AddListener(OnNextButtonClicked);
        }

        private void OnNextButtonClicked()
        {
            Debug.Log("Next");
            LevelFinishController.IncreasePlayerPrefs();
            LevelFinishController.RemovePreviousLevel();
            LevelFinishController.RefreshText();
        }
    }
}
