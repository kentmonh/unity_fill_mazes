using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using _Scripts.Entities.GamePlay.GamePlaySystem;
using _Scripts.Utility;
using _Scripts.Entities.GamePlay.Lines;

namespace _Scripts.Entities.GamePlay.Blocks
{
    public class Block : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
    {
        public Vector2 Position { get; set; }
        public bool Occupied { get; set; }
        public bool Available { get; set; }
        public bool Current { get; set; }
        public SpriteRenderer Sprite { get; set; }

        void Start()
        {
            if (Sprite == null)
            {
                Sprite = GetComponent<SpriteRenderer>();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickBlock();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
#if !UNITY_EDITOR
            OnClickBlock();
#endif
        }

        private void OnClickBlock()
        {
            if (Available && !Occupied)
            {
                Game.Path.Push(this);
                Game.UnsolvedBlocks -= 1;
                Game.SetCurrent(this);

                PathLineController.LinePath.Add(Position);
            }
            else
            {
                if (Occupied)
                {
                    while (Game.Path.Peek() != this)
                    {
                        Block popPoint = Game.Path.Pop();
                        popPoint.Occupied = false;
                        Game.UnsolvedBlocks += 1;
                        PathLineController.LinePath.RemoveAt(PathLineController.LinePath.Count - 1);
                    }
                    Game.SetCurrent(this);
                }
            }

            if (Game.UnsolvedBlocks == 0)
            {
                Game.FinishGame();
            }
        }    
    }
}
