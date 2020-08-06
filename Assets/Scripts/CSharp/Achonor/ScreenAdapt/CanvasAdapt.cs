using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScreenAdapt
{
    [Serializable]
    public class CanvasAdaptConfig
    {
        public Vector2 referenceResolution;
        public float matchWidthOrHeight;
    }

    public class CanvasAdapt : AdaptBase<CanvasAdaptConfig, CanvasScaler> {
        protected override void CopyProperty(CanvasAdaptConfig config) {
            base.CopyProperty(config);
            config.matchWidthOrHeight = mComponent.matchWidthOrHeight;
            config.referenceResolution = mComponent.referenceResolution;
        }

        protected override void ApplyConfig(CanvasAdaptConfig config) {
            base.ApplyConfig(config);
            mComponent.referenceResolution = config.referenceResolution;
            mComponent.matchWidthOrHeight = config.matchWidthOrHeight;
        }
    }

}
