using System;
using _Project.Code.Runtime.Shop.Models.Elements;
using UnityEngine;

namespace _Project.Code.Runtime.Shop.Views.Elements
{
    public abstract class BaseElementView : MonoBehaviour
    {
        public abstract Type LinkedElementType { get; }
        public abstract void SetElement(IElement element);
    }
}