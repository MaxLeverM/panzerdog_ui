using System;

namespace _Project.Code.Runtime.Models.RewardProcessor
{
    public class GameResourceRewardProcessor : IRewardProcessor
    {
        private readonly FinanceModel _financeModel;

        public Type RewardType => typeof(GameResourceReward);

        public GameResourceRewardProcessor(FinanceModel financeModel)
        {
            _financeModel = financeModel;
        }

        public void ProcessReward(IReward reward)
        {
            var gameResourceReward = (GameResourceReward)reward;
            _financeModel.Change(gameResourceReward.Resource.ResourceId, gameResourceReward.Resource.ResourceData.Amount.Value);
        }
    }
}