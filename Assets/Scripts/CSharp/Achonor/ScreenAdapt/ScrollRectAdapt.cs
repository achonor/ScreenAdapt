using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScreenAdapt {
	[Serializable]
	public class ScrollRectConfig {
		public bool vertical;
		public bool horizontal;
	}

	public class ScrollRectAdapt : AdaptBase<ScrollRectConfig, ScrollRect>
	{
        protected override void CopyProperty(ScrollRectConfig config) {
            base.CopyProperty(config);
			config.vertical = mComponent.vertical;
			config.horizontal = mComponent.horizontal;
		}

        protected override void ApplyConfig(ScrollRectConfig Config) {
            base.ApplyConfig(Config);
			mComponent.vertical = Config.vertical;
			mComponent.horizontal = Config.horizontal;
		}
    }
}

