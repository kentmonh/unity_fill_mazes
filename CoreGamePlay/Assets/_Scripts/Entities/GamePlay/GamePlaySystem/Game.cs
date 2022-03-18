using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Entities.GamePlay.Blocks;
using _Scripts.Utility;
using _Scripts.Entities.GamePlay.Lines;

namespace _Scripts.Entities.GamePlay.GamePlaySystem
{
    public class Game : MonoBehaviour
    {
        public static int UnsolvedBlocks { get; set; }
        public static Stack<Block> Path { get; set; }
        void Start()
        {
            // Setup the init gameplay
            Block firstblock = SetupBlocks.Blocks[0];
            if (firstblock.Sprite == null)
            {
                firstblock.Sprite = GetComponentInChildren<SpriteRenderer>();
            }
            SetCurrent(firstblock);

            // Set UnsolvedBlocks and Path
            Path = new Stack<Block>();
            Path.Push(firstblock);
            UnsolvedBlocks = SetupBlocks.Blocks.Length - 1;

            // Set LinePath
            PathLineController.LinePath.Add(firstblock.Position);
        }

        public static void SetCurrent(Block block)
        {
            // Remove all the availables and current
            for (int i = 0; i < SetupBlocks.Blocks.Length; i++)
            {
                SetupBlocks.Blocks[i].Current = false;
                SetupBlocks.Blocks[i].Available = false;
            }
            // Set current
            block.Current = true;
            block.Occupied = true;
            // Find availables 
            Vector2[] availables = new Vector2[4];
            for (int i = 0; i < GlobalVariables.aroundDirections.Length; i++)
            {
                availables[i] = block.Position + GlobalVariables.aroundDirections[i];
            }

            foreach (Block b in SetupBlocks.Blocks)
            {
                foreach (Vector2 pos in availables)
                {
                    if (b.Position == pos)
                    {
                        b.Available = true;
                        break;
                    }
                }
            }
        }

        public static void FinishGame()
        {
            Debug.Log("Finished Game");
        }
    }
}

