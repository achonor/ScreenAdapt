using ScreenAdapt;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScreenAdapt
{

	[Serializable]
	public class TransformAdaptConfig
	{
		public bool updateApply;
		public bool isActive;
		public Vector3 localPosition;
		public Vector3 localEulerAngles;
		public Vector3 localScale;
	}

	public class TransformAdapt : AdaptBase<TransformAdaptConfig, Transform>
	{
		protected override void ApplyConfig(TransformAdaptConfig config) {
			base.ApplyConfig(config);
			gameObject.SetActive(config.isActive);
			mComponent.localPosition = config.localPosition;
			mComponent.localEulerAngles = config.localEulerAngles;
			mComponent.localScale = config.localScale;
		}

		protected override void CopyProperty(TransformAdaptConfig config) {
			base.CopyProperty(config);
			config.isActive = gameObject.activeSelf;
			config.localPosition = mComponent.localPosition;
			config.localEulerAngles = mComponent.localEulerAngles;
			config.localScale = mComponent.localScale;
		}

        protected override void LateUpdate() {
            base.LateUpdate();
			if (CurrentConfig.updateApply) {
				ApplyConfig(CurrentConfig);
			}
        }
    }
}