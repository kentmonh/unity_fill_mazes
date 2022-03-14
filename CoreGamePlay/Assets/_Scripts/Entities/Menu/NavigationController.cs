using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Entities.UI.Buttons;
using _Scripts.Entities.UI.Canvas;

namespace _Scripts.Entities.Menu
{
    [RequireComponent(typeof(Button))]
    public class NavigationController : MonoBehaviour
    {
        [SerializeField] private Button _buttonPrevious;
        [SerializeField] private Button _buttonNext;

        private ISelectButtonsController selectButtonController;
        private CanvasManager canvasManager;

        void Start()
        {
            _buttonPrevious.onClick.AddListener(OnPreviousButtonClick);
            _buttonNext.onClick.AddListener(OnNextButtonClick);
            canvasManager = CanvasManager.GetInstance();

            switch (canvasManager.lastActiveCanvas.canvasType)
            {
                case CanvasType.MenuStageSelect:
                    selectButtonController = SelectStageButtonsController.GetInstance();
                    break;
                case CanvasType.MenuLevelSelect:
                    selectButtonController = SelectLevelButtonsController.GetInstance();
                    break;
                default:
                    break;
            }
            RefreshPage();
        }

        private void OnPreviousButtonClick()
        {
            selectButtonController.CurrentPage--;
            RefreshPage();
        }

        private void OnNextButtonClick()
        {
            selectButtonController.CurrentPage++;
            RefreshPage();
        }

        private void RefreshPage()
        {         
            selectButtonController.Refresh();
            if (selectButtonController.CurrentPage <= 0)
            {
                _buttonPrevious.gameObject.SetActive(false);
            }
            else
            {
                _buttonPrevious.gameObject.SetActive(true);
            }
            if ((selectButtonController.CurrentPage + 1) * selectButtonController.PageLevels >= selectButtonController.TotalLevels)
            {
                _buttonNext.gameObject.SetActive(false);
            }
            else
            {
                _buttonNext.gameObject.SetActive(true);
            }
        }
    }
}

