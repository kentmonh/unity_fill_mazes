using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Entities.GamePlay.Blocks;
using _Scripts.Utility;

namespace _Scripts.Entities.GamePlay.Lines
{
    public class PathLineController : MonoBehaviour
    {
        public static LineRenderer LineRenderer { get; set; }
        public static List<Vector3> LinePath { get; set; }
        void Start()
        {
            LineRenderer = GetComponent<LineRenderer>();
            LinePath = new List<Vector3>();
            LineRenderer.startColor = GlobalVariables.orange;
            LineRenderer.endColor = GlobalVariables.orange;
            LineRenderer.startWidth = 0.5f;
            LineRenderer.endWidth = 0.5f;
            LineRenderer.positionCount = 0;
        }

        void Update()
        {
            LineRenderer.positionCount = LinePath.Count;
            for (int i = 0; i < LinePath.Count; i++)
            {
                LineRenderer.SetPosition(i, LinePath[i] - SetupBlocks.Center);
                if (LinePath.Count > 1)
                {
                    LineRenderer.enabled = true;
                    if (i == LinePath.Count - 1)
                    {
                        if (LinePath[i].x == LinePath[i - 1].x)
                        {
                            if (LinePath[i].y > LinePath[i - 1].y)
                            {
                                LineRenderer.SetPosition(i, LinePath[i] - SetupBlocks.Center + new Vector3(0, 0.25f, 0));
                            }
                            else
                            {
                                LineRenderer.SetPosition(i, LinePath[i] - SetupBlocks.Center - new Vector3(0, 0.25f, 0));
                            }
                        }
                        if (LinePath[i].y == LinePath[i - 1].y)
                        {
                            if (LinePath[i].x > LinePath[i - 1].x)
                            {
                                LineRenderer.SetPosition(i, LinePath[i] - SetupBlocks.Center + new Vector3(0.25f, 0, 0));
                            }
                            else
                            {
                                LineRenderer.SetPosition(i, LinePath[i] - SetupBlocks.Center - new Vector3(0.25f, 0, 0));
                            }
                        }
                    }
                }
                else
                {
                    LineRenderer.enabled = false;
                }
            }
        }
    }
}

