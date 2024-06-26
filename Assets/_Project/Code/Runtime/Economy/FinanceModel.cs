﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.Serialization;

namespace _Project.Code.Runtime.Economy
{
    [Serializable]
    public class FinanceModel : ICloneable
    {
        [OdinSerialize] private Dictionary<GameResourceId, GameResourceData> _resources;

        public Dictionary<GameResourceId, GameResourceData> GameResources => _resources;

        public FinanceModel(Dictionary<GameResourceId, GameResourceData> resources)
        {
            _resources = resources;
        }

        public void Change(GameResourceId resourceId, int delta)
        {
            Set(resourceId, Get(resourceId) + delta);
        }

        public bool IsEnough(GameResourceId resourceId, int price)
        {
            return Get(resourceId) - price >= 0;
        }

        public int Get(GameResourceId resourceId)
        {
            return _resources.TryGetValue(resourceId, out var result) ? result.Amount.Value : 0;
        }

        public void Set(GameResourceId resourceId, int newValue)
        {
            if (_resources.TryGetValue(resourceId, out var resourceData))
            {
                if (resourceData.Amount.Value != newValue)
                    resourceData.Amount.Value = newValue;
            }
            else
            {
                _resources.Add(resourceId, new GameResourceData(newValue));
            }
        }

        public object Clone()
        {
            var dictionary = _resources.ToDictionary(x => x.Key, x => (GameResourceData)x.Value.Clone());
            return new FinanceModel(dictionary);
        }
    }
}