using System;
using _Project.Code.Runtime.Models.Elements;
using Sirenix.Serialization;

namespace _Project.Code.Runtime.Models
{
    [Serializable]
    public class OneElementItem : BaseItem
    {
        [OdinSerialize] private IElement _element;

        public IElement Element => _element;
    }
}