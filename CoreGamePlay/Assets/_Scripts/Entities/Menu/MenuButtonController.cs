using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Entities.UI.Canvas;
using _Scripts.Entities.Helper;
using _Scripts.Entities.GamePlay;

namespace _Scripts.Entities.Menu
{
    [RequireComponent(typeof(Button))]
    public class MenuButtonController : MonoBehaviour
    {
        [SerializeField] private MenuButtonType _menuButtonType;
        private CanvasManager canvasManager;
        private Button menuButton;
        private Text textLevel;
        private int btnLevel = 0;

        void Awake()
        {
            menuButton = GetComponent<Button>();
            textLevel = GetComponentInChildren<Text>();
            menuButton.onClick.AddListener(OnMenuButtonClicked);
            canvasManager = CanvasManager.GetInstance();
        }

        private void OnMenuButtonClicked()
        {
            switch (_menuButtonType)
            {
                case MenuButtonType.StageLevel:
                    PlayerPrefsManager.CurrentStage = btnLevel;
                    TextStageLevelController.TextStageLevel.text = "Stage " + PlayerPrefsManager.CurrentStage.ToString();
                    canvasManager.SwitchCanvas(CanvasType.MenuLevelSelect);
                    break;
                case MenuButtonType.GameLevel:
                    PlayerPrefsManager.CurrentLevel = btnLevel;
                    TextGameLevelController.RefreshGameLevelText();
                    canvasManager.SwitchCanvas(CanvasType.GamePlay);
                    break;
                default:
                    break;
            }
        }

        public void Setup(int level)
        {
            switch (_menuButtonType)
            {
                case MenuButtonType.StageLevel:
                    btnLevel = level;
                    textLevel.text = "Stage " + btnLevel.ToString();
                    break;
                case MenuButtonType.GameLevel:
                    btnLevel = level;
                    textLevel.text = btnLevel.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}