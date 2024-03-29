using System;
using System.Collections.Generic;
using _Project.Code.Runtime.Models;
using _Project.Code.Runtime.Utils;
using _Project.Code.Runtime.Views.Factories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Runtime.Views
{
    public class ShopItemElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _numberText;
        [SerializeField] private RectTransform _dataPanel;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Image _backgroundImg;
        [SerializeField] private List<BaseElementView> _elementPrefabs;
        [SerializeField] private Color EvenBackColor;
        [SerializeField] private Color OddBackColor;
        private BaseItem _item;
        public BaseItem Item => _item;
        public void Init(int number, BaseItem item, Action<BaseItem> OnBuyClick)
        {
            _item = item;
            _priceText.text = FinanceUtils.PriceToText(item.Price.ResourceData.Amount.Value);
            _buyButton.onClick.AddListener(() => OnBuyClick?.Invoke(item));
            SetNumber(number);
            ElementViewFactory elementViewFactory = new ElementViewFactory(_elementPrefabs);
            elementViewFactory.CreateElementViews(item, _dataPanel);
        }

        public void SetNumber(int number)
        {
            _numberText.text = number.ToString();
            _backgroundImg.color = number % 2 == 0 ? EvenBackColor : OddBackColor;
        }
    }
}