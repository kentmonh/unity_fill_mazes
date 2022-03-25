using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Entities.Helper;


namespace _Scripts.LevelSystem
{
    public class GetCurrentLevel
    {
        public List<Vector3> BlocksPath { get; set; }
        public List<int> Rows { get; set; }
        public List<int> Columns { get; set; }

        public GetCurrentLevel()
        {
            Debug.Log("GetCurrentLevel");
            BlocksPath = new List<Vector3>();
            Rows = new List<int>();
            Columns = new List<int>();

            GetLevelsForCurrentStage levels = new GetLevelsForCurrentStage();
            string levelPosition = levels.LevelsData[PlayerPrefsManager.CurrentLevel - 1];
            levelPosition = levelPosition.Substring(1, levelPosition.Length - 3);
            string[] positions = levelPosition.Split(new[] { "><" }, StringSplitOptions.None);

            foreach (string postion in positions)
            {
                string[] numbers = postion.Split(new[] { ", " }, StringSplitOptions.None);
                int x = int.Parse(numbers[0]);
                int y = int.Parse(numbers[1]);
                int z = 4;
                Rows.Add(x);
                Columns.Add(y);
                BlocksPath.Add(new Vector3(x, y, z));
            }
        }
    }
}

