using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScreenAdapt{
	public class AdaptManager : MonoBehaviour {

        public static AdaptManager Instance = null;

        private List<IAdaptBase> adaptBases = new List<IAdaptBase>();

        private bool currentIsLandscape = false;

        protected void Awake() {
            Instance = this;
            currentIsLandscape = IsLandscape();
        }

        private void Update() {
            bool newState = IsLandscape();
            if (newState != currentIsLandscape) {
                currentIsLandscape = newState;
                CallFunction();
            }
        }

        private void CallFunction(IAdaptBase adaptBase = null) {
            OnChange(adaptBase);
            if (currentIsLandscape) {
                OnLandscape(adaptBase);
            }
            else {
                OnPortrait(adaptBase);
            }
        }

        private void OnChange(IAdaptBase adaptBase = null) {
            if (null != adaptBase) {
                adaptBase.OnChange();
                return;
            }
            for (int i = 0; i < adaptBases.Count; i++) {
                adaptBases[i].OnChange();
            }
        }

        private void OnLandscape(IAdaptBase adaptBase = null) {
            if (null != adaptBase) {
                adaptBase.OnLandscape();
                return;
            }
            for (int i = 0; i < adaptBases.Count; i++) {
                adaptBases[i].OnLandscape();
            }
        }

        private void OnPortrait(IAdaptBase adaptBase = null) {
            if (null != adaptBase) {
                adaptBase.OnPortrait();
                return;
            }
            for (int i = 0; i < adaptBases.Count; i++) {
                adaptBases[i].OnPortrait();
            }
        }

        public void Register(IAdaptBase adaptBase) {
            if (adaptBases.Contains(adaptBase)) {
                return;
            }
            adaptBases.Add(adaptBase);
            CallFunction(adaptBase);
        }

        public void Remove(IAdaptBase adaptBase) {
            if (!adaptBases.Contains(adaptBase)) {
                return;
            }
            adaptBases.Remove(adaptBase);
        }

        public static bool IsLandscape() {
			return Screen.height < Screen.width;
		}
	}

}