using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using _Scripts.LevelSystem;
using _Scripts.Entities.Helper;

namespace _Scripts.Entities.GamePlay.Blocks
{
    public class SetupBlocks : MonoBehaviour

    {
        [SerializeField] private GameObject _blockObject;

        public static Block[] Blocks { get; set; }
        public static Vector3 Center { get; set; }

        private static List<GameObject> instantiateBlocks = new List<GameObject>();

        public void Start()
        {
            GetCurrentLevel currentLevel = new GetCurrentLevel();

            Center = new Vector2((float)currentLevel.Rows.Max() / 2, (float)currentLevel.Columns.Max() / 2);

            foreach (Vector3 position in currentLevel.BlocksPath)
            {
                var block = Instantiate(_blockObject, position - Center, Quaternion.identity);
                instantiateBlocks.Add(block);
                block.transform.SetParent(this.gameObject.transform);
            }
            _blockObject.SetActive(false);

            Blocks = GetComponentsInChildren<Block>();
            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i].Position = currentLevel.BlocksPath[i];
            }
        }

        public static void NewGame()
        {
            // Destroy old instantiate buttons
            foreach (GameObject block in instantiateBlocks)
            {
                DestroyImmediate(block);
            }
            instantiateBlocks.Clear();
        }
    }
}