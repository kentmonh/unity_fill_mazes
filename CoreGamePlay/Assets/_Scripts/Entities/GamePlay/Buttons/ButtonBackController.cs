using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Entities.UI.Canvas;

namespace _Scripts.Entities.GamePlay.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ButtonBackController : MonoBehaviour
    {
        private Button BackButton;
        private CanvasManager canvasManager;

        void Awake()
        {
            BackButton = GetComponent<Button>();
            BackButton.onClick.AddListener(OnBackButtonClicked);
            canvasManager = CanvasManager.GetInstance();
        }

        private void OnBackButtonClicked()
        {
            canvasManager.SwitchCanvas(CanvasType.MenuStageSelect);
        }
    }
}


