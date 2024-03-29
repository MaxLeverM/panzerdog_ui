using System;
using _Project.Code.Runtime.Models.Elements;
using _Project.Code.Runtime.Utils;
using TMPro;
using UnityEngine;

namespace _Project.Code.Runtime.Views
{
    public class GameResourceElementView : BaseElementView
    {
        [SerializeField] private TMP_Text _text;

        public override Type LinkedElementType => typeof(GameResourceElement);

        public override void SetElement(IElement element)
        {
            var gameResourceElement = element as GameResourceElement;
            if (gameResourceElement != null)
            {
                _text.text = FinanceUtils.PriceToText(gameResourceElement.gameResource.ResourceData.Amount.Value);
            }
        }
    }
}