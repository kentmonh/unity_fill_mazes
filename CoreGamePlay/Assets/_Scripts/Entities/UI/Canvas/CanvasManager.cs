using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using _Scripts.Entities.UI.Helper;

namespace _Scripts.Entities.UI.Canvas
{
    public class CanvasManager : Singleton<CanvasManager>
    {
        private List<CanvasController> CanvasControllerList { get; set; }
        private CanvasController lastActiveCanvas;

        protected override void Awake()
        {
            CanvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
            CanvasControllerList.ForEach(x => x.gameObject.SetActive(false));

            SwitchCanvas(CanvasType.MenuStageSelect);
        }

        public void SwitchCanvas(CanvasType type)
        {
            if (lastActiveCanvas != null)
            {
                lastActiveCanvas.gameObject.SetActive(false);
            }

            CanvasController desiredCanvas = CanvasControllerList.Find(x => x.canvasType == type);
            if (desiredCanvas != null)
            {
                desiredCanvas.gameObject.SetActive(true);
                lastActiveCanvas = desiredCanvas;
            }
            else 
            { 
                Debug.Log("The desired canvas was not found!"); 
            }
        }
    }
}
