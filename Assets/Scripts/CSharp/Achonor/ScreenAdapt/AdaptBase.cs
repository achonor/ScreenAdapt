using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScreenAdapt {
    public class AdaptBase<T, T1> : AdaptBehaviour, IAdaptBase where T : new() where T1 : Component
    {
        [ContextMenuItem("Copy Property", "Copy2LandscapeConfig")]
        [ContextMenuItem("Apply Config", "ApplyLandscapeConfig")]
        [SerializeField]
        protected T LandscapeConfig;

        [ContextMenuItem("Copy Property", "Copy2PortraitConfig")]
        [ContextMenuItem("Apply Config", "ApplyPortraitConfig")]
        [SerializeField]
        protected T PortraitConfig;

        protected T CurrentConfig {
            get {
                return IsLandscape() ? LandscapeConfig : PortraitConfig;
            }
        }

        private T1 _mComponent;
        protected T1 mComponent {
            get {
                if (null == _mComponent) {
                    _mComponent = GetBehaviour<T1>();
                }
                return _mComponent;
            }
        }

        private Dictionary<System.Type, Component> ComponentDict = new Dictionary<System.Type, Component>();
        protected T2 GetBehaviour<T2>() where T2 : Component {
            System.Type T1Type = typeof(T2);
            if (!ComponentDict.ContainsKey(T1Type)) {
                ComponentDict[T1Type] = GetComponent<T2>();
            }
            return ComponentDict[T1Type] as T2;
        }

        protected override void Awake() {
            base.Awake();
            AdaptManager.Instance.Register(this);
        }

        protected override void OnDestroy() {
            base.OnDestroy();
            if (null == AdaptManager.Instance) {
                return;
            }
            AdaptManager.Instance.Remove(this);
        }

        public static bool IsLandscape() {
            return AdaptManager.IsLandscape();
        }

        public virtual void OnChange() {
            ApplyConfig(CurrentConfig);
        }

        public virtual void OnLandscape() {
        }

        public virtual void OnPortrait() {
        }


        protected virtual void Reset() {
            Copy2LandscapeConfig();
            Copy2PortraitConfig();
        }

        public override void ApplyLandscapeConfig() {
            base.ApplyLandscapeConfig();
            if (null == LandscapeConfig) {
                return;
            }
            ApplyConfig(LandscapeConfig);
        }

        public override void ApplyPortraitConfig() {
            base.ApplyPortraitConfig();
            if (null == PortraitConfig) {
                return;
            }
            ApplyConfig(PortraitConfig);
        }

        protected void Copy2LandscapeConfig() {
            if (null == LandscapeConfig) {
                LandscapeConfig = new T();
            }
            CopyProperty(LandscapeConfig);
        }

        protected void Copy2PortraitConfig() {
            if (null == PortraitConfig) {
                PortraitConfig = new T();
            }
            CopyProperty(PortraitConfig);
        }

        protected virtual void ApplyConfig(T config) {
        
        }

        protected virtual void CopyProperty(T config) {

        }
    }
}
