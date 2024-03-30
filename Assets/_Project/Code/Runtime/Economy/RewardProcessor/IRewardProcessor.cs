using System;

namespace _Project.Code.Runtime.Models.RewardProcessor
{
    public interface IRewardProcessor
    {
        public Type RewardType { get; }
        public void ProcessReward(IReward reward);
    }
}