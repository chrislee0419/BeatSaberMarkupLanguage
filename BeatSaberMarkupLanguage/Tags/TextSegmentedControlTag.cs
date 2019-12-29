﻿using BeatSaberMarkupLanguage.TypeHandlers;
using BS_Utils.Utilities;
using HMUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace BeatSaberMarkupLanguage.Tags
{
    class TextSegmentedControlTag : BSMLTag
    {
        public override string[] Aliases => new[] { "text-segments" };

        public override GameObject CreateObject(Transform parent)
        {
            TextSegmentedControl prefab = Resources.FindObjectsOfTypeAll<TextSegmentedControl>().First(x => x.transform.parent.name == "PlayerStatisticsViewController");
            TextSegmentedControl textSegmentedControl = MonoBehaviour.Instantiate(prefab, parent, false);
            textSegmentedControl.name = "BSMLTextSegmentedControl";
            textSegmentedControl.SetPrivateField("_container", prefab.GetPrivateField<DiContainer>("_container"));
            (textSegmentedControl.transform as RectTransform).anchoredPosition = new Vector2(0, 0);
            foreach (Transform transform in textSegmentedControl.transform)
            {
                GameObject.Destroy(transform.gameObject);
            }
            return textSegmentedControl.gameObject;
        }
    }
}
