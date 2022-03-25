using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Entities.GamePlay.GamePlaySystem;
using _Scripts.Entities.GamePlay.Lines;

namespace _Scripts.Entities.GamePlay.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ButtonRestartController : MonoBehaviour
    {
        private Button RestartButton;

        void Awake()
        {
            RestartButton = GetComponent<Button>();
            RestartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            Game.RestartGame();
        }
    }
}
