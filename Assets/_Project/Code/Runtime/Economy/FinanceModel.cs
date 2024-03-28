using System;
using System.Collections.Generic;
using Sirenix.Serialization;

namespace _Project.Code.Runtime.Models
{
    [Serializable]
    public class FinanceModel
    {
        [OdinSerialize] private Dictionary<GameResourceId, GameResourceData> _resources;

        public void Change(GameResourceId resourceId, int delta)
        {
            Set(resourceId, Get(resourceId) + delta);
        }

        public bool IsEnough(GameResourceId resourceId, int delta)
        {
            return Get(resourceId) + delta >= 0;
        }

        public int Get(GameResourceId resourceId)
        {
            return _resources.TryGetValue(resourceId, out var result) ? result.Amount : 0;
        }

        public void Set(GameResourceId resourceId, int newValue)
        {
            if (_resources.TryGetValue(resourceId, out var resourceData))
            {
                if (resourceData.Amount != newValue)
                    resourceData.Amount = newValue;
            }
            else
            {
                _resources.Add(resourceId, new GameResourceData(newValue));
            }
        }
    }
}