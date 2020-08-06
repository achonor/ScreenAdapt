using ScreenAdapt;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScreenAdapt {

    [Serializable]
    public class GridLayoutGroupAdaptConfig {
        public RectOffset padding;
        public Vector2 cellSize;
        public Vector2 spacing;
        public GridLayoutGroup.Corner startCorner;
        public GridLayoutGroup.Axis startAxis;
        public TextAnchor childAlignment;
        public GridLayoutGroup.Constraint constraint;
        public int constraintCount;
    }

    public class GridLayoutGroupAdapt : AdaptBase<GridLayoutGroupAdaptConfig, GridLayoutGroup>
    {
        protected override void ApplyConfig(GridLayoutGroupAdaptConfig config) {
            base.ApplyConfig(config);
            mComponent.padding = config.padding;
            mComponent.cellSize = config.cellSize;
            mComponent.spacing = config.spacing;
            mComponent.startCorner = config.startCorner;
            mComponent.startAxis = config.startAxis;
            mComponent.childAlignment = config.childAlignment;
            mComponent.constraint = config.constraint;
            mComponent.constraintCount = config.constraintCount;
        }

        protected override void CopyProperty(GridLayoutGroupAdaptConfig config) {
            base.CopyProperty(config);
            config.padding = mComponent.padding;
            config.cellSize = mComponent.cellSize;
            config.spacing = mComponent.spacing;
            config.startCorner = mComponent.startCorner;
            config.startAxis = mComponent.startAxis;
            config.childAlignment = mComponent.childAlignment;
            config.constraint = mComponent.constraint;
            config.constraintCount = mComponent.constraintCount;
        }
    }
}


