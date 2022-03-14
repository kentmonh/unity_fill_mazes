using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Entities.UI.Buttons
{
    public interface ISelectButtonsController
    {
        int CurrentPage { get; set; }
        int TotalLevels { get; set; }
        int PageLevels { get; set; }
        void Refresh();
    }
}

