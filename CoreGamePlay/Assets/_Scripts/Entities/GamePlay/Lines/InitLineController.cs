using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Utility;
using _Scripts.Entities.GamePlay.GamePlaySystem;
using _Scripts.Entities.GamePlay.Blocks;

namespace _Scripts.Entities.GamePlay.Lines
{
    public class InitLineController : MonoBehaviour
    {
        public static LineRenderer InitLineRenderer { get; set; }
        void Start()
        {
            InitLineRenderer = GetComponent<LineRenderer>();

            InitLineRenderer.startColor = GlobalVariables.orange;
            InitLineRenderer.endColor = GlobalVariables.orange;
            InitLineRenderer.startWidth = 0.5f;
            InitLineRenderer.endWidth = 0.5f;

            InitLineRenderer.positionCount = 2;
            InitLineRenderer.SetPosition(0, new Vector3(Game.Path.Peek().Position.x, Game.Path.Peek().Position.y, 0) - SetupBlocks.Center - new Vector3(0, 0.25f, 0));
            InitLineRenderer.SetPosition(1, new Vector3(Game.Path.Peek().Position.x, Game.Path.Peek().Position.y, 0) - SetupBlocks.Center + new Vector3(0, 0.25f, 0));
        }

        public static void NewGame()
        {
            InitLineRenderer.positionCount = 0;
        }
    }
}
