using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScreenAdapt {
	[Serializable]
	public class AnimatorAdaptConfig {
		[Tooltip("设置状态机参数: int|Blend|0")]
		public List<string> animParams;
		public string animName;
	}

	public class AnimatorAdapt : AdaptBase<AnimatorAdaptConfig, Animator> {

        protected override void ApplyConfig(AnimatorAdaptConfig config) {
            base.ApplyConfig(config);
			for (int i = 0; i < config.animParams.Count; i++) {
				string[] param = config.animParams[i].Split('|');
				string typeName = param[0].ToLower();
				if ("int" == typeName) {
					mComponent.SetInteger(param[1], int.Parse(param[2]));
				}
				else if ("float" == typeName) {
					mComponent.SetFloat(param[1], float.Parse(param[2]));
				}
				else if ("bool" == typeName) {
					mComponent.SetBool(param[1], bool.Parse(param[2]));
				}
				else if ("trigger" == typeName) {
					mComponent.SetTrigger(param[1]);
				}
				else {
					Debug.LogError("不支持的类型：" + typeName);
				}
			}
			if (!string.IsNullOrEmpty(config.animName)) {
				mComponent.Play(config.animName);
			}
		}
    }
}
