using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using ScreenAdapt;

namespace ScreenAdaptEditor {
    public static class AdaptEditor{
        [MenuItem("Achonor/ApplyScreenAdapt", priority = 0)]
        public static void ApplyScreenAdapt() {
            Vector2 screenSize = GetGameViewSize();
            AdaptBehaviour[] adapts = Resources.FindObjectsOfTypeAll<AdaptBehaviour>();
            for (int i = 0; i < adapts.Length; i++) {
                if (screenSize.x < screenSize.y) {
                    adapts[i].ApplyPortraitConfig();
                }
                else {
                    adapts[i].ApplyLandscapeConfig();
                }
            }
        }

        /// <summary>
        /// 获取Game View的分辨率
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static Vector2 GetGameViewSize() {
            System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
            System.Reflection.MethodInfo GetMainGameView = T.GetMethod("GetMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            System.Object Res = GetMainGameView.Invoke(null, null);
            var gameView = (UnityEditor.EditorWindow)Res;
            var prop = gameView.GetType().GetProperty("currentGameViewSize", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var gvsize = prop.GetValue(gameView, new object[0] { });
            var gvSizeType = gvsize.GetType();
            int height = (int)gvSizeType.GetProperty("height", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).GetValue(gvsize, new object[0] { });
            int width = (int)gvSizeType.GetProperty("width", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).GetValue(gvsize, new object[0] { });
            return new Vector2(width, height);
        }
    }
}
