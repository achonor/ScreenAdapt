using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScreenAdapt
{
    public interface IAdaptBase
    {
        void OnChange();

        void OnLandscape();

        void OnPortrait();
    }
}
