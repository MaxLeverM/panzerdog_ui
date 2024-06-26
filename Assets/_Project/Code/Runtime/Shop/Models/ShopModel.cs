﻿using System;
using System.Linq;
using _Project.Code.Runtime.Shop.Models.Items;
using Sirenix.Serialization;
using UniRx;

namespace _Project.Code.Runtime.Shop.Models
{
    [Serializable]
    public class ShopModel : ICloneable
    {
        [OdinSerialize] public ReactiveCollection<BaseItem> _shopItems { get; private set; }

        public ShopModel(BaseItem[] shopItems)
        {
            _shopItems = new ReactiveCollection<BaseItem>(shopItems);
        }

        public object Clone()
        {
            return new ShopModel(_shopItems.ToArray());
        }
    }
}