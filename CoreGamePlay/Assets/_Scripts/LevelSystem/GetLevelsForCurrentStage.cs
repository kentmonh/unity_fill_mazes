using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Entities.Helper;

namespace _Scripts.LevelSystem
{
    public class GetLevelsForCurrentStage
    {
        public List<string> LevelsData { get; set; }

        public GetLevelsForCurrentStage()
        {
            TextAsset levelTextAsset = Resources.Load("LevelsData/Stage" + PlayerPrefsManager.CurrentStage) as TextAsset;
            LevelsData = new List<string>();
            if (levelTextAsset)
            {
                // Handling levelTextAsset
                string completeText = levelTextAsset.text;
                string[] levels = completeText.Split(new string[] { "\n" }, System.StringSplitOptions.None);
                foreach (string level in levels)
                {
                    LevelsData.Add(level);
                }
            }
            else
            {
                Debug.LogError("No levelTextAsset File");
            }
        }
    }
}
