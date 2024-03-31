using System;
using _Project.Code.Runtime.Shop.Models.Elements;
using Sirenix.Serialization;

namespace _Project.Code.Runtime.Shop.Models.Items
{
    [Serializable]
    public class OneElementItem : BaseItem
    {
        [OdinSerialize] private IElement _element;

        public IElement Element => _element;
    }
}