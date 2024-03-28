using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code.Runtime.Models
{
    [Serializable]
    public class DefaultItem : BaseItem
    {
        [SerializeField] private List<string> _descriptions;
        [SerializeField] private List<Sprite> _sprites;
    }
}