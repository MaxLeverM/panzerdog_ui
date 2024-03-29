﻿using System.Collections.Generic;
using _Project.Code.Runtime.Models;
using _Project.Code.Runtime.Models.Elements;
using UnityEngine;

namespace _Project.Code.Runtime.Views.Factories
{
    public class ElementViewFactory
    {
        private List<BaseElementView> _elementPrefabs;

        public ElementViewFactory(List<BaseElementView> elementPrefabs)
        {
            _elementPrefabs = elementPrefabs;
        }

        public BaseElementView[] CreateElementViews(BaseItem baseItem, RectTransform dataPanel)
        {
            switch (baseItem)
            {
                case OneElementItem oneElementItem:
                    return CreateElementViewsInternal(new[] { oneElementItem.Element }, dataPanel);
                case TwoElementsItem twoElementsItem:
                    return CreateElementViewsInternal(new[] { twoElementsItem.FirstElement, twoElementsItem.SecondElement },
                        dataPanel);
                default:
                    return null;
            }
        }

        private BaseElementView[] CreateElementViewsInternal(IElement[] elements, RectTransform dataPanel)
        {
            BaseElementView[] elementViews = new BaseElementView[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                foreach (var elementPrefab in _elementPrefabs)
                {
                    if (elementPrefab.LinkedElementType == elements[i].GetType())
                    {
                        var elementView = GameObject.Instantiate(elementPrefab, dataPanel);
                        elementView.SetElement(elements[i]);
                        elementViews[i] = elementView;
                        break;
                    }
                }
            }

            return elementViews;
        }
    }
}