using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Entities.UI.Buttons;

namespace _Scripts.Entities.Menu
{
    [RequireComponent(typeof(Button))]
    public class NavigationController : MonoBehaviour
    {
        [SerializeField] private Button _buttonPrevious;
        [SerializeField] private Button _buttonNext;

        private SelectStageButtonsController selectStageButton;

        void Start()
        {
            _buttonPrevious.onClick.AddListener(OnPreviousButtonClick);
            _buttonNext.onClick.AddListener(OnNextButtonClick);
            selectStageButton = SelectStageButtonsController.GetInstance();
        }

        private void OnPreviousButtonClick()
        {
            selectStageButton.CurrentPage--;
            selectStageButton.Refresh();
        }

        private void OnNextButtonClick()
        {
            selectStageButton.CurrentPage++;
            selectStageButton.Refresh();
        }
    }
}

