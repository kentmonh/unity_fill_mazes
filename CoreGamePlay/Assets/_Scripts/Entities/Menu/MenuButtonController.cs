using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Entities.UI.Canvas;
using _Scripts.Entities.Helper;

namespace _Scripts.Entities.Menu
{
    [RequireComponent(typeof(Button))]
    public class MenuButtonController : MonoBehaviour
    {
        [SerializeField] private MenuButtonType _menuButtonType;
        private CanvasManager canvasManager;
        private Button menuButton;

        [SerializeField] private Text _textLevel;
        private int btnLevel = 0;

        private void Start()
        {
            menuButton = GetComponent<Button>();
            menuButton.onClick.AddListener(OnMenuButtonClicked);
            canvasManager = CanvasManager.GetInstance();
        }

        private void OnMenuButtonClicked()
        {
            switch (_menuButtonType)
            {
                case MenuButtonType.StageLevel:
                    PlayerPrefsManager.CurrentStage = btnLevel;
                    TextStageLevelController.TextStageLevel.text = "Stage " + btnLevel.ToString();
                    canvasManager.SwitchCanvas(CanvasType.MenuLevelSelect);
                    break;
                case MenuButtonType.GameLevel:
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
                    _textLevel.text = "Stage " + btnLevel.ToString();
                    break;
                case MenuButtonType.GameLevel:
                    btnLevel = level;
                    _textLevel.text = btnLevel.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}