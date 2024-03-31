using System;
using _Project.Code.Runtime.Shop.Models.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Runtime.Shop.Views.Elements
{
    public class SpriteElementView : BaseElementView
    {
        [SerializeField] private Image _image;

        public override Type LinkedElementType => typeof(SpriteElement);
        
        public override void SetElement(IElement element)
        {
            var spriteElement = element as SpriteElement;
            _image.sprite = spriteElement.image;
        }
    }
}