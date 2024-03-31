using System;
using System.Collections.Generic;
using _Project.Code.Runtime.Economy;
using _Project.Code.Runtime.Economy.RewardProcessor;
using UnityEngine;

namespace _Project.Code.Runtime.Shop.Models.Items
{
    [Serializable]
    public abstract class BaseItem
    {
        [SerializeField] private GameResource _price;
        [SerializeField] private List<IReward> _rewards;

        public GameResource Price => _price;
        public List<IReward> Rewards => _rewards;
    }
}