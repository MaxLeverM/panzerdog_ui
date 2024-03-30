using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code.Runtime.Models.RewardProcessor
{
    public class RewardProcessor
    {
        private Dictionary<Type, IRewardProcessor> _rewardProcessors;

        public RewardProcessor()
        {
            _rewardProcessors = new Dictionary<Type, IRewardProcessor>();
        }

        public void RegisterProcessor(IRewardProcessor processor)
        {
            if (_rewardProcessors.ContainsKey(processor.RewardType))
            {
                Debug.LogError($"Reward processor for {processor.RewardType.Name} reward type, already registered!");
                return;
            }

            _rewardProcessors.Add(processor.RewardType, processor);
        }

        public void RemoveProcessor<T>() where T : IReward
        {
            if (!_rewardProcessors.ContainsKey(typeof(T)))
            {
                Debug.LogError($"Сannot remove a processor for a type {typeof(T).Name} because it has not been registered!");
                return;
            }

            _rewardProcessors.Remove(typeof(T));
        }

        public void Process(IEnumerable<IReward> rewards)
        {
            if (rewards == null)
            {
                return;
            }

            foreach (var reward in rewards)
            {
                if (_rewardProcessors.TryGetValue(reward.GetType(), out var processor))
                {
                    processor.ProcessReward(reward);
                }
                else
                {
                    Debug.LogError($"It is impossible to process the reward {reward.GetType().Name} because the RewardProcessor is not registered for it!");
                }
            }
        }
    }
}