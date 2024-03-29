using System;
using _Project.Code.Runtime.Models.Elements;
using UnityEngine;

namespace _Project.Code.Runtime.Views
{
    public abstract class BaseElementView : MonoBehaviour
    {
        public abstract Type LinkedElementType { get; }
        public abstract void SetElement(IElement element);
    }
}