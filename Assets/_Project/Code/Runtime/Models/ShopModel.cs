using System;
using System.Collections.Generic;
using Sirenix.Serialization;

namespace _Project.Code.Runtime.Models
{
    [Serializable]
    public class ShopModel
    {
        [OdinSerialize] private List<BaseItem> _shopItems;
    }
}