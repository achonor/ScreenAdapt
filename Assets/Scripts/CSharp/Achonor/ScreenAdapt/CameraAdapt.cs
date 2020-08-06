using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScreenAdapt
{
    [Serializable]
    public class CameraAdaptConfig
    {
        public float orthographicSize;
    }
    public class CameraAdapt : AdaptBase<CameraAdaptConfig, Camera>
    {
        protected override void CopyProperty(CameraAdaptConfig config) {
            base.CopyProperty(config);
            config.orthographicSize = mComponent.orthographicSize;
        }

        protected override void ApplyConfig(CameraAdaptConfig config) {
            base.ApplyConfig(config);
            mComponent.orthographicSize = config.orthographicSize;
        }
    }
}
