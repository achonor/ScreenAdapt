using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScreenAdapt {

	[Serializable]
	public class UnityEventString : UnityEvent<string> {
	}

	[Serializable]
	public class CallbackAdaptConfig
	{
		public string param;
		public UnityEventString changeCallback;
	}

	public class CallbackAdapt : AdaptBase<CallbackAdaptConfig, MonoBehaviour> {

        protected override void ApplyConfig(CallbackAdaptConfig config) {
            base.ApplyConfig(config);
			config.changeCallback.Invoke(config.param);
		}
	}
}
