using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Entities.Menu;
using _Scripts.Entities.UI.Helper;

namespace _Scripts.Entities.UI.Buttons
{
    public class SelectStageButtonsController : Singleton<SelectStageButtonsController>
    {
        [SerializeField] private GameObject _buttonSelectStage;

        private MenuButtonController[] ButtonSelectStages { get; set; }

        private List<GameObject> instantiateButtons = new List<GameObject>();
        public int CurrentPage { get; set; }

        private int totalStages = 25;
        private int pageStages = 6;

        void Start()
        {
            CurrentPage = 0;
            Refresh();
        }

        public void Refresh()
        {
            // Destroy old instantiate buttons
            foreach (GameObject button in instantiateButtons)
            {
                DestroyImmediate(button);
            }
            instantiateButtons.Clear();

            int remainStages = totalStages - CurrentPage * pageStages;
            if (remainStages >= pageStages)
            {
                remainStages = pageStages;
            }

            int y = 720;
            for (int i = 0; i < remainStages - 1; i++)
            {
                y -= 240;
                var buttonSelectStage = Instantiate(_buttonSelectStage, new Vector3(0, 0, 0), Quaternion.identity);
                instantiateButtons.Add(buttonSelectStage);
                buttonSelectStage.transform.SetParent(this.gameObject.transform);
                RectTransform rtButtonSelectStage = buttonSelectStage.GetComponent<RectTransform>();
                rtButtonSelectStage.anchoredPosition = Vector3.zero;
                rtButtonSelectStage.localPosition = new Vector3(0, y, 0);
            }

            ButtonSelectStages = GetComponentsInChildren<MenuButtonController>(false);

            for (int i = 0; i < ButtonSelectStages.Length; i++)
            {
                int level = CurrentPage * pageStages + i + 1;
                ButtonSelectStages[i].Setup(level);
            }
        }
    }
}





