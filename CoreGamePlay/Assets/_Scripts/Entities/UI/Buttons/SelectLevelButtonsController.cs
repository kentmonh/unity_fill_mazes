using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Entities.Menu;
using _Scripts.Entities.UI.Helper;

namespace _Scripts.Entities.UI.Buttons
{
    public class SelectLevelButtonsController : Singleton<SelectLevelButtonsController>, ISelectButtonsController
    {
        [SerializeField] private GameObject _buttonSelectLevel;
        private MenuButtonController[] ButtonSelectLevels { get; set; }
        
        private List<GameObject> instantiateButtons = new List<GameObject>();

        private int buttonSize = 120;
        private int gapSize = 30;
        private int leftLimit = -300;
        private int topLimit = 720;
        private int rightLimit = 300;

        public int CurrentPage { get; set; }
        public int TotalLevels { get; set; }
        public int PageLevels { get; set; }

        public SelectLevelButtonsController()
        {
            CurrentPage = 0;
            TotalLevels = 300;
            PageLevels = 50;
        }

        public void Refresh()
        {
            // Destroy old instantiate buttons
            foreach (GameObject button in instantiateButtons)
            {
                DestroyImmediate(button);
            }
            instantiateButtons.Clear();

            int remainLevels = TotalLevels - CurrentPage * PageLevels;
            if (remainLevels >= PageLevels)
            {
                remainLevels = PageLevels;
            }

            int x = leftLimit;
            int y = topLimit;

            for (int i = 0; i < remainLevels - 1; i++)
            {
                x += buttonSize + gapSize;
                var buttonSelectLevel = Instantiate(_buttonSelectLevel, new Vector3(0, 0, 0), Quaternion.identity);
                instantiateButtons.Add(buttonSelectLevel);
                buttonSelectLevel.transform.SetParent(this.gameObject.transform);
                RectTransform rtButtonSelectLevel = buttonSelectLevel.GetComponent<RectTransform>();
                rtButtonSelectLevel.anchoredPosition = Vector3.zero;

                if (x > rightLimit)
                {
                    x = leftLimit;
                    y -= buttonSize + gapSize;
                }
                rtButtonSelectLevel.localPosition = new Vector3(x, y, 0);
            }

            ButtonSelectLevels = GetComponentsInChildren<MenuButtonController>(false);

            for (int i = 0; i < ButtonSelectLevels.Length; i++)
            {
                int level = CurrentPage * PageLevels + i + 1;
                ButtonSelectLevels[i].Setup(level);
            }
        }
    }
}

