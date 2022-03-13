using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Entities.UI.Canvas;

namespace _Scripts.Entities.Menu
{
    [RequireComponent(typeof(Button))]
    public class MenuButtonController : MonoBehaviour
    {
        [SerializeField] private MenuButtonType _menuButtonType;
        private CanvasManager canvasManager;
        private Button menuButton;

        [SerializeField] private Text _textStageLevel;
        private int btnStageLevel = 0;

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
                    canvasManager.SwitchCanvas(CanvasType.MenuLevelSelect);
                    break;
                case MenuButtonType.GameLevel:
                    canvasManager.SwitchCanvas(CanvasType.GamePlay);
                    break;
                default:
                    break;
            }
        }

        public void Setup(int stageLevel)
        {
            switch (_menuButtonType)
            {
                case MenuButtonType.StageLevel:
                    btnStageLevel = stageLevel;
                    _textStageLevel.text = "Stage " + btnStageLevel.ToString();
                    break;
                case MenuButtonType.GameLevel:
                    break;
                default:
                    break;
            }
        }
    }
}