using System;
using UnityEngine;

namespace _Project.Code.Runtime.Models
{
    [Serializable]
    public class CurrencyRewardItem : BaseItem
    {
        [SerializeField] private GameResource _reward;
    }
}