using System;
using _Project.Code.Runtime.Models.Elements;
using TMPro;
using UnityEngine;

namespace _Project.Code.Runtime.Views.Elements
{
    public class TextElementView : BaseElementView
    {
        [SerializeField] private TMP_Text _text;

        public override Type LinkedElementType => typeof(TextElement);

        public override void SetElement(IElement element)
        {
            var textElement = element as TextElement;
            _text.text = textElement.text;
        }
    }
}