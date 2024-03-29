using System;
using UnityEngine;

namespace _Project.Code.Runtime.Models
{
    [Serializable]
    public abstract class BaseItem
    {
        [SerializeField] private GameResource _price;

        public GameResource Price => _price;
    }
}