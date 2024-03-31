using System;
using _Project.Code.Runtime.Shop.Models.Elements;
using Sirenix.Serialization;

namespace _Project.Code.Runtime.Shop.Models.Items
{
    [Serializable]
    public class TwoElementsItem : BaseItem
    {
        [OdinSerialize] private IElement _firstElement;
        [OdinSerialize] private IElement _secondElement;

        public IElement FirstElement => _firstElement;
        public IElement SecondElement => _secondElement;
    }
}