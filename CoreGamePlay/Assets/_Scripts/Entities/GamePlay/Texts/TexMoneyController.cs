using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Entities.Helper;

namespace _Scripts.Entities.GamePlay.Texts
{
    public class TexMoneyController : MonoBehaviour
    {
        private Text MoneyText { get; set; }

        void Awake()
        {
            MoneyText = GetComponent<Text>();
            MoneyText.text = PlayerPrefsManager.Money.ToString();
        }
    }
}

