using System;
using System.Linq;
using Sirenix.Serialization;
using UniRx;

namespace _Project.Code.Runtime.Models
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